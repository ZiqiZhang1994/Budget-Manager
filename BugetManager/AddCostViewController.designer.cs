// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BugetManager
{
    [Register ("AddCostViewController")]
    partial class AddCostViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSubmit { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel datelable { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField lblcost { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField lbldetails { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField lblname { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField lbltype { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIDatePicker MyDatePicker { get; set; }

        [Action ("DateTimeChanger:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DateTimeChanger (UIKit.UIDatePicker sender);

        [Action ("KeyUpChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void KeyUpChanged (UIKit.UITextField sender);

        [Action ("UIButton118_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton118_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnSubmit != null) {
                btnSubmit.Dispose ();
                btnSubmit = null;
            }

            if (datelable != null) {
                datelable.Dispose ();
                datelable = null;
            }

            if (lblcost != null) {
                lblcost.Dispose ();
                lblcost = null;
            }

            if (lbldetails != null) {
                lbldetails.Dispose ();
                lbldetails = null;
            }

            if (lblname != null) {
                lblname.Dispose ();
                lblname = null;
            }

            if (lbltype != null) {
                lbltype.Dispose ();
                lbltype = null;
            }

            if (MyDatePicker != null) {
                MyDatePicker.Dispose ();
                MyDatePicker = null;
            }
        }
    }
}