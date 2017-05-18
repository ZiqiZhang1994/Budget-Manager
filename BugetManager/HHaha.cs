using Foundation;
using System;
using UIKit;
using CoreGraphics;
using Cross.Pie.iOS;

namespace BugetManager
{
    public partial class HHaha : UIView
    {
CrossPie Pie { get; set; }
        public HHaha (IntPtr handle) : base (handle)
        {

Pie = new CrossPie(new CGRect(0.0, 100.0, 380.0, 380.0));

	this.AddSubview(Pie);


Pie.StartAngle = 90.0;
Pie.Add(new PieItem { Title = "one", Value = 1.5 });
	Pie.Add(new PieItem { Title = "two", Value = 2 });
	Pie.Add(new PieItem { Title = "three", Value = 2.5 });
	Pie.Add(new PieItem { Title = "four", Value = 3.5 });
	Pie.Update();
			Pie.IsTitleOnTop = false;
        }
    }
}