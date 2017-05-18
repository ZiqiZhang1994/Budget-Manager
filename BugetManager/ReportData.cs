using System;
namespace BugetManager
{
	public class ReportData
	{
private string _CostName;
private float _CostValue;
private string _CostType;
private DateTime _CostDate;
private string _CostDetails;


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

public ReportData()
{
}
public ReportData(float costvalue, string costtype)
{
	_CostValue = costvalue;
	_CostType = costtype;
}
	}
}
