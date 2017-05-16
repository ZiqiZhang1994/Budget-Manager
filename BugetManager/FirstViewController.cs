using System;

using UIKit;

namespace BugetManager
{
	public partial class FirstViewController : UIViewController
	{
		protected FirstViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			Database_interaction db = new Database_interaction();

			Budget budget = db.GetBudget(DateTime.Now);
			float totalcost = db.GetTotalCostMonth(DateTime.Now);
			if (budget != null)
			{
				lblmonth.Text = "This Month's Budget: " + budget.BudgetAmount.ToString();
				lblRemaining.Text = "Remaining Budget: " + (budget.BudgetAmount - totalcost).ToString();
				lblTotalCost.Text = "Total Cost This Month: " + totalcost.ToString();
			}
			else
			{
				lblmonth.Text = "This Month's Budget: Not Set";
				lblRemaining.Text = "Remaining Budget: 0"; 
				lblTotalCost.Text = "Total Cost This Month: 0";
			}
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void UIBarButtonItem138_Activated(UIBarButtonItem sender)
		{
			//Menu list

			var alert = UIAlertController.Create("Budget Menu", "Choose one action you need", UIAlertControllerStyle.ActionSheet);
   
			if (alert.PopoverPresentationController != null)
				alert.PopoverPresentationController.BarButtonItem = sender as UIBarButtonItem;  

			alert.AddAction (UIAlertAction.Create ("Ok", UIAlertActionStyle.Cancel, null));


			alert.AddAction (UIAlertAction.Create ("Add Cost", UIAlertActionStyle.Default,null));

			alert.AddAction (UIAlertAction.Create ("Cost Simulator", UIAlertActionStyle.Default,null));

			alert.AddAction (UIAlertAction.Create ("Setup Warning", UIAlertActionStyle.Default, null));

			alert.AddAction (UIAlertAction.Create ("Edit", UIAlertActionStyle.Default, null));

			PresentViewController(alert, animated: true, completionHandler: null);
		}


		partial void UIButton69_TouchUpInside(UIButton sender)
		{var textInputAlertController = UIAlertController.Create("Set Budget", "Put digit into the field", UIAlertControllerStyle.Alert);

//Add Text Input
textInputAlertController.AddTextField(textField => {
                });

			//Add Actions
			Database_interaction db = new Database_interaction();
                var cancelAction = UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, alertAction => Console.WriteLine("Cancel was Pressed"));
			var okayAction = UIAlertAction.Create("Okay", UIAlertActionStyle.Default, alertAction => buttonOKClicked(textInputAlertController));

textInputAlertController.AddAction(cancelAction);
                textInputAlertController.AddAction(okayAction);

				//Present Alert
				PresentViewController(textInputAlertController, true, null);





		}
		private void buttonOKClicked(UIAlertController textInputAlertController)
		{
			Database_interaction db = new Database_interaction();
			db.AddBudget(new Budget(float.Parse(textInputAlertController.TextFields[0].Text), DateTime.Now));
			      
Budget budget = db.GetBudget(DateTime.Now);

float totalcost = db.GetTotalCostMonth(DateTime.Now);
			if (budget != null)
			{
				lblmonth.Text = "This Month's Budget: " + budget.BudgetAmount.ToString();
				lblRemaining.Text = "Remaining Budget: " + (budget.BudgetAmount - totalcost).ToString();

lblTotalCost.Text = "Total Cost This Month: " + totalcost.ToString();
			}
			else
			{
				lblmonth.Text = "This Month's Budget: Not Set";
				lblRemaining.Text = "Remaining Budget: 0"; 
				lblTotalCost.Text = "Total Cost This Month: 0";
			}
		}
	}
}
