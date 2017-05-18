using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace BugetManager
{
	public partial class ReportProgressViewController : UIViewController
	{
		public ReportProgressViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();


			MyScroll.ContentSize = MyView.Frame.Size;
			MyScroll.Scrolled += (sender, e) =>
			{
				MyPager.CurrentPage = (nint)(MyScroll.ContentOffset.X / MyScroll.Frame.Width);
			};



			var costManager = CostManager.Create();

			ReportTable.Source = new ReportResource(costManager.Costs, this);



			ReportTable.RowHeight = UITableView.AutomaticDimension;

			ReportTable.EstimatedRowHeight = 40f;

			ReportTable.ReloadData();

			DisplaySuggestion(costManager.Costs);

		}


		public Dictionary<string, float> CostTypeCollect(List<Cost> costList)
		{

			Dictionary<string, float> typeDiction = new Dictionary<string, float>();
			foreach (Cost a in costList)
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



			return typeDiction;
		}
		public void DisplaySuggestion(List<Cost> costList)
		{
			Dictionary<string, float> reportItems = CostTypeCollect(costList);
			float max;
			float min;
			KeyValuePair<string, float> maxType = new KeyValuePair<string, float>();
			KeyValuePair<string, float> minType = new KeyValuePair<string, float>();
			foreach (KeyValuePair<string, float> a in reportItems)
			{
				max = a.Value;
				min = a.Value;
				if (a.Value > max)
				{
					max = a.Value;
					maxType = a;
				}


				if (a.Value < min)
				{
					min = a.Value;
					minType = a;
				}
			}

			textfield1.Text = "Seems you like spend many moeny in " + maxType.Key + ".";
			textfield2.Text = "Seems you don't always do activities on " + minType.Key + ".";
			textfield3.Text = "Your most cost is " + maxType.Key + "which you cost" + maxType.Value.ToString() + "." + " You also spend least money on " + minType.Value + "which you cost" + minType.Value.ToString() + ".";

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