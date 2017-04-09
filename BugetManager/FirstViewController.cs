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
 
			alert.AddAction (UIAlertAction.Create ("Add Cost", UIAlertActionStyle.Default, null));

			alert.AddAction (UIAlertAction.Create ("Cost Simulator", UIAlertActionStyle.Default, null));

			alert.AddAction (UIAlertAction.Create ("Setup Warning", UIAlertActionStyle.Default, null));

			alert.AddAction (UIAlertAction.Create ("Edit", UIAlertActionStyle.Default, null));

			PresentViewController(alert, animated: true, completionHandler: null);
		}
	}
}
