using System;
namespace BugetManager
{
	public class ReportData
	{
		private float _CostValue;
		private string _CostType;

		public string CostType
		{
			get { return _CostType; }
			set { _CostType = value; }
		}

		public float CostValue
		{
			get { return _CostValue; }
			set { _CostValue = value; }
		}

		public ReportData(string costtype, float costvalue)
		{
			_CostType = costtype;
			_CostValue = costvalue;

		}

public ReportData()
{

		}
	}
}
