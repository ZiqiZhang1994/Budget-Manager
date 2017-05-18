using System;
using UIKit;
using Foundation;
using System.Collections.Generic;
using System.Linq;

namespace BugetManager
{
	public class ReportResource : UITableViewSource
	{

		List<Cost> CostItems;
		List<ReportData> ReportItems;
		ReportProgressViewController hostViewCOntroller;
		string cellIdentifier = "ReportCell";

		public ReportResource(List<Cost> costs, ReportProgressViewController hostVC)
		{
			CostItems = costs;

			hostViewCOntroller = hostVC;


		}

		private void CostTypeCollect()
		{
			ReportItems = new List<ReportData>();
			List<Cost> aTempList = new List<Cost>();
			aTempList = CostItems;
			List<Cost> bTempList = new List<Cost>();
			bTempList = CostItems;
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
				ReportItems.Add(tempReport);
			}
				
		}


		public override nint RowsInSection(UITableView tableview, nint section)
		{
                        CostTypeCollect();
			return ReportItems.Count;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{

			//new UIAlertView("Alert", "You touched: " + tableItems[indexPath.Row], null, "OK", null).Show();

			tableView.DeselectRow(indexPath, true);
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			/*
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier, indexPath);
			Cost item = CostItems[indexPath.Row];
			if (cell == null)
				cell = new UITableViewCell(UITableViewCellStyle.Subtitle, cellIdentifier);
			cell.TextLabel.Text = item.CostName;
			cell.DetailTextLabel.Text = item.CostDetails;

			*/

			var cell = (ProgressTableCell)tableView.DequeueReusableCell(cellIdentifier, indexPath);

			ReportData item = ReportItems[indexPath.Row];

			cell.UpdateCell(item);


			return cell;

		}
	}
}
