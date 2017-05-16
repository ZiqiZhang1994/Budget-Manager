using Foundation;
using System;
using UIKit;

namespace BugetManager
{
	public partial class MonthTableCell : UITableViewCell
	{
		public MonthTableCell(IntPtr handle) : base(handle)
		{
		}

		internal void UpdateCell(Cost costs)
		{

			product.Text = costs.CostName;
			time.Text = costs.CostDate.ToString();
			money.Text = costs.CostValue.ToString();
		}
	}
}