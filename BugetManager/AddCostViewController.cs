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
			//string name=
			//db_inter.AddCost();
		}
	}
}