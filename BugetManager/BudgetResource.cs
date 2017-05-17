using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace BugetManager
{
	public class BudgetResource : UITableViewSource
	{


		List<Cost> BudgetItems = new List<Cost>();
		string cellIdentifier = "BudgetCell";

		BugetSimulatorViewController hostViewCOntroller;


		public BudgetResource(List<Cost> budgets, BugetSimulatorViewController hostVC)
		{
			BudgetItems = budgets;
			hostViewCOntroller = hostVC;

		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{

			var cell = tableView.DequeueReusableCell(cellIdentifier, indexPath);


			cell.TextLabel.Text = BudgetItems[indexPath.Row].ToString();

			Cost item = BudgetItems[indexPath.Row];
			if (cell == null)
				cell = new UITableViewCell(UITableViewCellStyle.Subtitle, cellIdentifier);
			cell.TextLabel.Text = item.CostName;
			cell.DetailTextLabel.Text = item.CostValue.ToString();


			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{

			return BudgetItems.Count;
		}


		public override nint NumberOfSections(UITableView tableView)

		{

			return 1;


		}


		public IList<Cost> Objects

		{

			get { return BudgetItems; }

		}
	}
}
