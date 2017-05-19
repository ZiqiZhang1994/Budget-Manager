using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using System.Threading;

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



			new Thread(new ThreadStart(LoadToTable)).Start();


		}
		private void LoadToTable()
		{
			InvokeOnMainThread(delegate
			{
				for (int i = 0; i < 3; i++)
				{
					/*UIAlertView alert = new UIAlertView()
					{
						Title = "Loading...",
						Message = i.ToString() + " time(s) try"
					};*/

					//alert.Show();
					var costManager = CostManager.Create();

					ReportTable.Source = new ReportResource(costManager.Costs, this);



					ReportTable.RowHeight = UITableView.AutomaticDimension;

					ReportTable.EstimatedRowHeight = 40f;

					ReportTable.ReloadData();

					DisplaySuggestion(costManager.Costs);
					//alert.Dispose();
				}

			});


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
			float max = 0;
			float min = float.MaxValue;
			string maxType = "";

			string minType = "";

			foreach (KeyValuePair<string, float> a in reportItems)
			{
				if (a.Value > max)
				{
					max = a.Value;
					maxType = a.Key;
				}


				if (a.Value < min)
				{
					min = a.Value;
					minType = a.Key;
				}
			}



			textfield1.Text = "Seems you like spend many moeny in " + maxType + ".";
			textfield2.Text = "Seems you don't always do activities on " + minType + ".";
			textfield3.Text = "Your most cost is " + maxType + " which you cost " + max.ToString() + " on." + " You also spend least money on " + minType + " which you cost " + min + " on.";

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