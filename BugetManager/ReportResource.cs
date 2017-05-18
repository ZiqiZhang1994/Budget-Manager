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

		public ReportResource()
		{

		}

		public ReportResource(List<Cost> costs, ReportProgressViewController hostVC)
		{
			CostItems = costs;
			ReportItems = CostTypeCollect();
			hostViewCOntroller = hostVC;


		}

		public List<ReportData> CostTypeCollect()
		{

			List<ReportData> tempItems = new List<ReportData>();
			Dictionary<string, float> typeDiction = new Dictionary<string, float>();
			foreach (Cost a in CostItems)
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
