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
Dictionary<string, float> typeDiction = new Dictionary<string, float>();
			foreach (Cost a in tempList)
			{
				if (typeDiction.ContainsKey(a.CostType) == false)
				{
					typeDiction.Add(a.CostType, a.CostValue);
				}
				else
				{
					typeDiction[a.CostType] += a.CostValue;
				}
			}
			foreach (KeyValuePair<string, float> c in typeDiction)
			{
				ReportData tempdata = new ReportData(c.Key, c.Value);
tempItems.Add(tempdata);
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

						
			Pie.ItemSelected += (object sender, PieItem e) => 
			{
				e.IsPull = !e.IsPull;
				e.IsBold = e.IsPull;
				Pie.Update();
			};

		}
	}
}