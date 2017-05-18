using Foundation;
using System;
using UIKit;
using CoreGraphics;
using Cross.Pie.iOS;

namespace BugetManager
{
	public partial class Report : UIViewController
	{
		public Report(IntPtr handle) : base(handle)
		{
		}
				CrossPie Pie { get; set; }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			displayChart();


			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in us
		}

		private void displayChart()
		{
						
			Pie = new CrossPie(new CGRect(0.0, 100.0, 380.0, 380.0));
			this.View.AddSubview(Pie);

			Pie.StartAngle = 90.0;

			Pie.Add(new PieItem { Title = "one", Value = 1.5 });
			Pie.Add(new PieItem { Title = "two", Value = 2 });
			Pie.Add(new PieItem { Title = "three", Value = 2.5 });
			Pie.Add(new PieItem { Title = "four", Value = 3.5 });
			Pie.Update();
		}
	}
}