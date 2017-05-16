// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace BugetManager
{
    [Register ("FirstViewController")]
    partial class FirstViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblHighest { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblmonth { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblRemaining { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTotalCost { get; set; }

        [Action ("UIButton1094_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton1094_TouchUpInside (UIKit.UIButton sender);

        [Action ("UIButton69_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton69_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (lblHighest != null) {
                lblHighest.Dispose ();
                lblHighest = null;
            }

            if (lblmonth != null) {
                lblmonth.Dispose ();
                lblmonth = null;
            }

            if (lblRemaining != null) {
                lblRemaining.Dispose ();
                lblRemaining = null;
            }

            if (lblTotalCost != null) {
                lblTotalCost.Dispose ();
                lblTotalCost = null;
            }
        }
    }
}