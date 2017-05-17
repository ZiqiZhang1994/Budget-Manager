using Foundation;
using System;
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

		public BugetSimulatorViewController(IntPtr handle) : base(handle)
		{

		}
		public override void ViewDidLoad()
		{


			budget = db.GetBudget(DateTime.Now);
			if (budget!= null)
			{
				lblMonthBudget.Text = "This Month's Budget: " + budget.BudgetAmount.ToString();
			}
			else
			{
				lblMonthBudget.Text = "This Month's Budget: NotSet.";
			}
			 totalcost = db.GetTotalCostMonth(DateTime.Now);
			lblTotalCostThisMonth.Text = "Total Cost This Month: " + totalcost.ToString();

			lblRemaningBudget.Text = "Remaning Budget: " + (budget.BudgetAmount - totalcost).ToString();

			lblTotalCostPlanned.Text = "Total Cost Planned: Not Set";


var budgetManager = BudgetManagementController.Create();
						
			tablePlannedCost.Source=dataSource = new BudgetResource(budgetManager.Budgets, this);

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
			//Add to Table cell


			Cost plannedcost = new Cost(txtname.Text, float.Parse(txtValue.Text), "", DateTime.Now, "");
			AddNewItem(plannedcost);
			//update the Label
			plannedcostlist.Add(plannedcost);

			float totalplannedcost = 0;
			foreach (Cost c in plannedcostlist)
			{
				totalplannedcost += c.CostValue;
			}
			lblTotalCostPlanned.Text ="Total Cost Planned: "+ totalplannedcost.ToString();

			lblRemaningBudget.Text ="Remaining Budget: "+ (budget.BudgetAmount - totalcost - totalplannedcost).ToString();

			if ((budget.BudgetAmount - totalcost - totalplannedcost+plannedcost.CostValue) > 0 && (budget.BudgetAmount - totalcost - totalplannedcost) <= 0)
			{
				UIAlertView alert = new UIAlertView()
				{
					Title = "Warning!!",
					Message = "You are out of Budget!!!"
				};
				alert.AddButton("OK");
				alert.Show();

			
			}


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
			tablePlannedCost.Source = null;
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
		public	void DeleteRow(NSIndexPath indexPath)
		{
			plannedcostlist.RemoveAt(indexPath.Row);


			tablePlannedCost.DeleteRows(new[] { indexPath }, UITableViewRowAnimation.Fade);




		}
	}
}