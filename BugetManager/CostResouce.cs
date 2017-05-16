using System;
using UIKit;
using Foundation;
using System.Collections.Generic;

namespace BugetManager
{
	public class CostResource : UITableViewSource
	{

		List<Cost> CostItems;
		ThisMonthViewController hostViewCOntroller;
		string cellIdentifier = "CostCell";

		public CostResource(List<Cost> costs, ThisMonthViewController hostVC)

		{
			CostItems = costs;

			hostViewCOntroller = hostVC;

		}


		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return CostItems.Count;
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

			var cell = (MonthTableCell)tableView.DequeueReusableCell(cellIdentifier, indexPath);

			Cost item = CostItems[indexPath.Row];

			cell.UpdateCell(item);


			return cell;

		}
	}
}
