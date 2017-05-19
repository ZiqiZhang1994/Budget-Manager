using System;
using System.Collections.Generic;

namespace BugetManager
{
	public class CostManager
	{
		private static CostManager _instance = null;
		public List<Cost> Costs;
		private Database_interaction db = new Database_interaction();

		public static CostManager Create()

		{

			//if (_instance == null)
				_instance = new CostManager();

			return _instance;

		}


		internal CostManager()

		{

			Costs = db.GetCostList(DateTime.Now);
		}




	}
}
