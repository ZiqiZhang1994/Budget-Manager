using Foundation;
using System;
using UIKit;

namespace BugetManager
{
    public partial class AddCostViewController : UIViewController
    {
		private Database_interaction db_inter;
        public AddCostViewController (IntPtr handle) : base (handle)
        {
			db_inter = new Database_interaction();
        }

partial void UIButton118_TouchUpInside(UIButton sender)
		{
			bool parseOK;
			string name = lblname.Text;
			string costvalue = lblcost.Text;
			float cost;
			parseOK = float.TryParse(costvalue, out cost);
			if (!parseOK)
			{
				var alert1 = new UIAlertView("Error", "The Cost Must Be digit", null, "OK", null);
				alert1.Show();
				return;
			}
			string type = lbltype.Text;
			DateTime date = (System.DateTime)date_times.Date;
			string details = lbldetails.Text;


			db_inter.AddCost(new Cost(name,cost,type,date,details));//add cost

			var alert = new UIAlertView("", "The Cost has been added!!", null, "OK", null);
			alert.Show();
		}


	}

}