using Foundation;
using System;
using UIKit;

namespace BugetManager
{
	public partial class tabBarViewController : UITabBarController
	{
		public tabBarViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

		}
		partial void UIBarButtonItem1955_Activated(UIBarButtonItem sender)
		{
			var alert = UIAlertController.Create("Budget Menu", "Choose one action you need", UIAlertControllerStyle.ActionSheet);

			if (alert.PopoverPresentationController != null)
				alert.PopoverPresentationController.BarButtonItem = sender as UIBarButtonItem;

			alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));


			alert.AddAction(UIAlertAction.Create("Add Cost", UIAlertActionStyle.Default, (obj) => AddCostFunc()));

			alert.AddAction(UIAlertAction.Create("Cost Simulator", UIAlertActionStyle.Default, (obj) => SimulatorFunc()));

			alert.AddAction(UIAlertAction.Create("View Report", UIAlertActionStyle.Default, (obj) => Chart()));

			alert.AddAction(UIAlertAction.Create("Edit", UIAlertActionStyle.Default, null));

			PresentViewController(alert, animated: true, completionHandler: null);


		}
		private void AddCostFunc()
		{
			UIStoryboard board = UIStoryboard.FromName("Main", null);

			UIViewController ctrl = (UIViewController)board.InstantiateViewController("AddCostController");

			NavigationController.PushViewController(ctrl, true);

		}
		private void SimulatorFunc()
		{
			UIStoryboard board = UIStoryboard.FromName("Main", null);

			UIViewController ctrl = (UIViewController)board.InstantiateViewController("BudgetSimulatorController");

			NavigationController.PushViewController(ctrl, true);

		}

		private void Chart()
		{
			UIStoryboard board = UIStoryboard.FromName("Main", null);

			UIViewController ctrl = (UIViewController)board.InstantiateViewController("Report");

			NavigationController.PushViewController(ctrl, true);
		}
	}
}