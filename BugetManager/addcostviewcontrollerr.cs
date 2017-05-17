using Foundation;
using System;
using UIKit;

namespace BugetManager
{
	public partial class addcostviewcontrollerr : UIViewController
	{
		Database_interaction db_inter = new Database_interaction();
		public addcostviewcontrollerr() : base("addcostviewcontrollerr", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
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
			DateTime date = DateTime.Now;
			string details = lbldetails.Text;


			db_inter.AddCost(new Cost(name, cost, type, date, details));//add cost

			//var alert = new UIAlertView("", "The Cost has been added!!", null, "OK", null);
			//alert.Show();
		}


		partial void BtnDate_TouchUpInside(UIButton sender)
		{
		}
	}
}


