using Foundation;
using System;
using UIKit;
using System.Threading;

namespace BugetManager
{
	public partial class ThisMonthViewController : UIViewController
	{
		public ThisMonthViewController(IntPtr handle) : base(handle)
		{
		}

		Thread tableViewThread;

		public override void ViewDidLoad()
		{

			base.ViewDidLoad();
			//NavigationController.Title = "Monthly Cost";
			CostTable.RowHeight = UITableView.AutomaticDimension;
			CostTable.EstimatedRowHeight = 40f;




			tableViewThread=new Thread(new ThreadStart(ConstantlyRefresh));
			tableViewThread.Start();
			/*var costManager = CostManager.Create();

			CostTable.Source = new CostResource(costManager.Costs, this);

			CostTable.RowHeight = UITableView.AutomaticDimension;
			CostTable.EstimatedRowHeight = 40f;
			CostTable.ReloadData();*/



		}
		protected override void Dispose(bool disposing)
		{

			tableViewThread.Abort();
			base.Dispose(disposing);


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


		private void ConstantlyRefresh()
		{
			do
			{
				
				InvokeOnMainThread(
					delegate{
						var costManager = CostManager.Create();
						CostTable.Source = new CostResource(costManager.Costs, this);

						CostTable.ReloadData();
					});
				Thread.Sleep(10000);
			} while (true);
		}
	}
}