using Foundation;
using System;
using System.Threading;
using UIKit;
using System.IO;
using System.Collections.Generic;

namespace BugetManager
{
	public partial class BugetSimulatorViewController : UIViewController
	{
		BudgetResource dataSource;
		Database_interaction db = new Database_interaction();
		List<Cost> plannedcostlist = new List<Cost>();
		float totalcost;
		Budget budget;
		Mutex mut = new Mutex();


		public BugetSimulatorViewController(IntPtr handle) : base(handle)
		{

		}
		public override void ViewDidLoad()
		{


			UIImage img = UIImage.FromFile("BackGround.png");
			img = img.Scale(View.Frame.Size);
			this.View.BackgroundColor = UIColor.FromPatternImage(img);


			txtValue.Placeholder = "Must Be Didigt";
			budget = db.GetBudget(DateTime.Now);
			if (budget != null)
			{
				lblMonthBudget.Text = "This Month's Budget: " + budget.BudgetAmount.ToString();
			lblTotalCostThisMonth.Text = "Total Cost This Month: " + totalcost.ToString();

			lblRemaningBudget.Text = "Remaning Budget: " + (budget.BudgetAmount - totalcost).ToString();

lblTotalCostPlanned.Text = "Total Cost Planned: Not Set";
			}
			else
			{
				lblMonthBudget.Text = "This Month's Budget: NotSet.";
				lblRemaningBudget.Text = "Remaning Budget: 0";

			}
			totalcost = db.GetTotalCostMonth(DateTime.Now);
			lblTotalCostThisMonth.Text = "Total Cost This Month: " + totalcost.ToString();


			lblTotalCostPlanned.Text = "Total Cost Planned: Not Set";


			var budgetManager = BudgetManagementController.Create();

			budgetManager.Budgets.Clear();

			tablePlannedCost.Source = dataSource = new BudgetResource(budgetManager.Budgets, this);

			ReadPlannedCost();

		}




		void AddNewItem(Cost cost)

		{

			dataSource.Objects.Insert(0, cost);


			using (var indexPath = NSIndexPath.FromRowSection(0, 0))
				tablePlannedCost.InsertRows(new[] { indexPath }, UITableViewRowAnimation.Automatic);

		}



		partial void UIButton2001_TouchUpInside(UIButton sender)
		{
			new Thread(new ThreadStart(ButtonAddFunc)).Start();


		}
		private void ButtonAddFunc()
		{
			mut.WaitOne();
			//Add to Table cell

			InvokeOnMainThread(delegate
			{
				Cost plannedcost = new Cost(txtname.Text, float.Parse(txtValue.Text), "", DateTime.Now, "");
				AddNewItem(plannedcost);
				//update the Label
				plannedcostlist.Add(plannedcost);

				float totalplannedcost = 0;
				foreach (Cost c in plannedcostlist)
				{
					totalplannedcost += c.CostValue;
				}
				lblTotalCostPlanned.Text = "Total Cost Planned: " + totalplannedcost.ToString();

				lblRemaningBudget.Text = "Remaining Budget: " + (budget.BudgetAmount - totalcost - totalplannedcost).ToString();

				if ((budget.BudgetAmount - totalcost - totalplannedcost + plannedcost.CostValue) > 0 && (budget.BudgetAmount - totalcost - totalplannedcost) <= 0)
				{
					UIAlertView alert = new UIAlertView()
					{
						Title = "Warning!!",
						Message = "You are out of Budget!!!"
					};
					alert.AddButton("OK");
					alert.Show();


				}
			});


			mut.ReleaseMutex();

		}




		partial void BtnSave_TouchUpInside(UIButton sender)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string filename = DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_PlannedCost.csv";
			string filepath = Path.Combine(path, filename);

			using (StreamWriter sr = new StreamWriter(filepath))
			{
				//get datafrom tableview and write to local file

				foreach (Cost c in plannedcostlist)
				{
					sr.WriteLine(c.CostName + "," + c.CostValue);
				}

			}
		}

		private void ReadPlannedCost()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string filename = DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_PlannedCost.csv";
			string filepath = Path.Combine(path, filename);
			if (File.Exists(filepath))
			{
				using (StreamReader sr = new StreamReader(filepath))
				{
					//get datafrom tableview and write to local file

					string data = "";
					while ((data = sr.ReadLine()) != null)
					{
						string[] data1 = data.Split(',');
						plannedcostlist.Add(new Cost(data1[0], float.Parse(data1[1]), "", DateTime.Now, ""));
					}

				}
				float plannedtotalcost = 0;
				foreach (Cost c in plannedcostlist)
				{
					AddNewItem(c);
					plannedtotalcost += c.CostValue;
				}
				lblRemaningBudget.Text = "Remaning Budget: " + (budget.BudgetAmount - totalcost - plannedtotalcost).ToString();

				lblTotalCostPlanned.Text = "Total Cost Planned: " + plannedtotalcost.ToString();
			}
		}
		public void DeleteRow(NSIndexPath indexPath)
		{
			plannedcostlist.RemoveAt(plannedcostlist.Count - indexPath.Row - 1);


			tablePlannedCost.DeleteRows(new[] { indexPath }, UITableViewRowAnimation.Fade);




		}

		partial void KeyUpChanged(UITextField sender)
		{
			if (txtValue.Text != "")
			{
				char last = txtValue.Text[txtValue.Text.Length - 1];
				if (char.IsDigit(last) == false)
				{
					txtValue.Text = txtValue.Text.Remove(txtValue.Text.Length - 1, 1);

				}
			}
		}
	}
}