using Foundation;
using System;
using UIKit;

namespace BugetManager
{
	public partial class ThisMonthViewController : UIViewController
	{
		public ThisMonthViewController(IntPtr handle) : base(handle)
		{
		}


		public override void ViewDidLoad()
		{

			base.ViewDidLoad();




			var costManager = CostManager.Create();

			CostTable.Source = new CostResource(costManager.Costs, this);

			CostTable.RowHeight = UITableView.AutomaticDimension;
			CostTable.EstimatedRowHeight = 40f;
			CostTable.ReloadData();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
		}

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);
		}
	}
}