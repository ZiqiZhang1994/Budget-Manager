using Foundation;
using System;
using UIKit;
using CoreGraphics;
using Cross.Pie.iOS;
using System.Collections.Generic;

namespace BugetManager
{
	public partial class Report : UIViewController
	{
		public Report(IntPtr handle) : base(handle)
		{
		}
				CrossPie Pie { get; set; }
		UITableViewSource tempSource;
List<Cost> tempList = new List<Cost>();
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
List<ReportData> report = new List<ReportData>();

var costManager = CostManager.Create();
			tempList = costManager.Costs;
			report = CostTypeCollect();
			displayChart(report);


			// Perform any additional setup after loading the view, typically from a nib.
		}

		public List<ReportData> CostTypeCollect()
		{
			
			List<ReportData> tempItems = new List<ReportData>();
			List<Cost> aTempList = new List<Cost>();
			aTempList = tempList;
			List<Cost> bTempList = new List<Cost>();
			bTempList = tempList;
			foreach (Cost a in aTempList)
			{
				ReportData tempReport = new ReportData();

				float sum = 0;
				foreach (Cost b in bTempList)
				{
					if (a == b)
					{
						sum += b.CostValue;
					}
				}
				tempReport.CostType = a.CostType;
				tempReport.CostValue = sum;
				tempItems.Add(tempReport);
			}
			return tempItems;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in us
		}

		private void displayChart(List<ReportData> report)
		{
				

			Pie = new CrossPie(new CGRect(0.0, 100.0, 380.0, 380.0));
			this.View.AddSubview(Pie);

			Pie.StartAngle = 90.0;
			Pie.Title = "Cost Pie Chart";
			Pie.IsTitleOnTop = true;
			foreach (ReportData a in report)
			{
				Pie.Add(new PieItem { Title = a.CostType, Value = a.CostValue });
			}


			Pie.Update();
		}
	}
}