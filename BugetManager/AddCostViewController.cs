using Foundation;
using System;
using UIKit;

namespace BugetManager
{
	public partial class AddCostViewController : UIViewController
	{
		private Database_interaction db_inter;
		private DateTime tempDate;
		public AddCostViewController(IntPtr handle) : base(handle)
		{
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

		}

		partial void UIButton118_TouchUpInside(UIButton sender)
		{
			db_inter = new Database_interaction();
			bool parseOK;
			string name = lblname.Text;
			string costvalue = lblcost.Text;
			float cost;
			parseOK = float.TryParse(costvalue, out cost);
			if (!parseOK)
			{

				UIAlertView alert1 = new UIAlertView()
				{
					Title = "Error",
					Message = "The Cost Must Be digit!!"
				};
				alert1.AddButton("OK");
				alert1.Show();
				return;
			}
			string type = lbltype.Text;
			DateTime date = tempDate;//picker's time
			string details = lbldetails.Text;


			db_inter.AddCost(new Cost(name, cost, type, date, details));//add cost


			UIAlertView alert2 = new UIAlertView()
			{
				Title = "Add Successfully",
				Message = "The Cost has been added!!"
			};
			alert2.AddButton("OK");
			alert2.Show();
		}



		partial void DateTimeChanger(UIDatePicker sender)
		{

			DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
			NSDate date = MyDatePicker.Date;
			tempDate = reference.AddSeconds(date.SecondsSinceReferenceDate);
			datelable.Text = tempDate.ToString();
		}
	}

}