using Foundation;
using System;
using UIKit;

namespace BugetManager
{
	public partial class heyheyhey : UITabBarController
	{
		public heyheyhey(IntPtr handle) : base(handle)
		{
		}

		partial void UIBarButtonItem1955_Activated(UIBarButtonItem sender)
		{
			var alert = UIAlertController.Create("Budget Menu", "Choose one action you need", UIAlertControllerStyle.ActionSheet);

			if (alert.PopoverPresentationController != null)
				alert.PopoverPresentationController.BarButtonItem = sender as UIBarButtonItem;

			alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));


			alert.AddAction(UIAlertAction.Create("Add Cost", UIAlertActionStyle.Default, (obj) => tryyy()));

			alert.AddAction(UIAlertAction.Create("Cost Simulator", UIAlertActionStyle.Default, null));

			alert.AddAction(UIAlertAction.Create("Setup Warning", UIAlertActionStyle.Default, null));

			alert.AddAction(UIAlertAction.Create("Edit", UIAlertActionStyle.Default, null));

			PresentViewController(alert, animated: true, completionHandler: null);
		}

		private void tryyy()
		{
			UIStoryboard board = UIStoryboard.FromName("Main", null);

			UIViewController ctrl = (UIViewController)board.InstantiateViewController("AddCostController");

			NavigationController.PushViewController(ctrl, true);
		}

	}
}