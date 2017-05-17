using Foundation;
using System;
using UIKit;

namespace BugetManager
{
    public partial class BugetSimulatorViewController : UIViewController
    {
		Database_interaction db = new Database_interaction();
        public BugetSimulatorViewController (IntPtr handle) : base (handle)
        {

        }
		public override void ViewDidLoad()
		{
			Budget bg = db.GetBudget(DateTime.Now);
			if (bg != null)
			{
				lblMonthBudget.Text ="This Month's Budget: "+ bg.BudgetAmount.ToString();
			}
			else
			{
				lblMonthBudget.Text = "This Month's Budget: NotSet.";
			}
			float totalcost = db.GetTotalCostMonth(DateTime.Now);
			lblTotalCostThisMonth.Text = "Total Cost This Month: " + totalcost.ToString();

			lblRemaningBudget.Text = "Remaning Budget: " + (bg.BudgetAmount - totalcost).ToString();

			lblTotalCostPlanned.Text = "Total Cost Planned: Not Set";




		}


		partial void UIButton2001_TouchUpInside(UIButton sender)
		{
			//Add to Table cell


			//update the 
		}
	}
}