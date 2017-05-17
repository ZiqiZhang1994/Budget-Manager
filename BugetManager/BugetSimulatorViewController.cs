using Foundation;
using System;
using UIKit;
using System.IO;

namespace BugetManager
{
	public partial class BugetSimulatorViewController : UIViewController
	{
		BudgetResource dataSource;
		Database_interaction db = new Database_interaction();
		public BugetSimulatorViewController(IntPtr handle) : base(handle)
		{

		}
		public override void ViewDidLoad()
		{
			Budget bg = db.GetBudget(DateTime.Now);
			if (bg != null)
			{
				lblMonthBudget.Text = "This Month's Budget: " + bg.BudgetAmount.ToString();
			}
			else
			{
				lblMonthBudget.Text = "This Month's Budget: NotSet.";
			}
			float totalcost = db.GetTotalCostMonth(DateTime.Now);
			lblTotalCostThisMonth.Text = "Total Cost This Month: " + totalcost.ToString();

			lblRemaningBudget.Text = "Remaning Budget: " + (bg.BudgetAmount - totalcost).ToString();

			lblTotalCostPlanned.Text = "Total Cost Planned: Not Set";


var budgetManager = BudgetManagementController.Create();
						
			tablePlannedCost.Source=dataSource = new BudgetResource(budgetManager.Budgets, this);



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


			AddNewItem(new Cost(txtname.Text, float.Parse(txtValue.Text), "", DateTime.Now, ""));
			//update the Label
		}



		partial void BtnSave_TouchUpInside(UIButton sender)
		{

		}
	}
}