using Foundation;
using System;
using UIKit;

namespace BugetManager
{
	public partial class ProgressTableCell : UITableViewCell
	{
		public ProgressTableCell(IntPtr handle) : base(handle)
		{
		}

		internal void UpdateCell(ReportData report)
		{

			Database_interaction db = new Database_interaction();

			Budget budget = db.GetBudget(DateTime.Now);

			type.Text = report.CostType;
			total.Text = report.CostValue.ToString();
			//progressBar.MaxValue = budget.BudgetAmount;
			progressBar.Progress = report.CostValue / budget.BudgetAmount;

			//progressBar.Value = report.CostValue;
		}
	}
}