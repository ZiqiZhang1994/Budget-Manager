using System;
using System.Collections.Generic;

namespace BugetManager
{
	public class BudgetManagementController
	{
private static BudgetManagementController _instance = null;
public List<Cost> Budgets;
private Database_interaction db = new Database_interaction();

public static BudgetManagementController Create()

{

	if (_instance == null)
				_instance = new BudgetManagementController();

	return _instance;

}




internal BudgetManagementController()

{
			Budgets = new List<Cost>();

	
}
	}
}
