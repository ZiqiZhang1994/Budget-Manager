using System;
namespace BugetManager
{
	public class Cost
	{
		private string _CostName;
		private float _CostValue;
		private string _CostType;
		private DateTime _CostDate;
		private string _CostDetails;

		public string CostName
		{
			set { _CostName = value;}
			get { return _CostName; }
		}
		public float CostValue
		{
			get { return _CostValue; }
			set { _CostValue = value; }
		}
		public string CostType
		{
			get { return _CostType; }
			set { _CostType = value; }
		}
		public DateTime CostDate
		{
			get { return _CostDate; }
			set { _CostDate = value; }
		}
		public string CostDetails
		{
			get { return _CostDetails; }
			set { _CostDetails = value; }
		}
		public Cost()
		{
		}
		public Cost(string name, float costvalue, string costtype, DateTime costdate, string costdetails)
		{
			_CostName = name;
			_CostValue = costvalue;
			_CostType = costtype;
			_CostDate = costdate;
			_CostDetails = costdetails;
		}


	}
}
