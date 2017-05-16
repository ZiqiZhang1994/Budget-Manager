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
    [Register ("MonthTableCell")]
    partial class MonthTableCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel money { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel product { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel time { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (money != null) {
                money.Dispose ();
                money = null;
            }

            if (product != null) {
                product.Dispose ();
                product = null;
            }

            if (time != null) {
                time.Dispose ();
                time = null;
            }
        }
    }
}