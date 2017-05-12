using System;
namespace BugetManager
{
	public class Budget
	{
		private float _BudgetAmount;
		private DateTime _BudgetTime;
		private string _BudgetPurpose;

		public float BudgetAmount
		{
			get { return _BudgetAmount; }
			set { _BudgetAmount = value; }
		}
		public DateTime BudgetTime
		{
			get { return _BudgetTime; }
			set { _BudgetTime = value; }
		}
		public string BudgetPurpose
		{
			get { return _BudgetPurpose; }
			set { _BudgetPurpose = value; }
		}
		public Budget(float budgetamount, DateTime time)
		{
			_BudgetTime = time;
			_BudgetAmount = budgetamount;
		}
	}
}
