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
    [Register ("ReportProgressViewController")]
    partial class ReportProgressViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPageControl MyPager { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView MyScroll { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView MyView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ProgressTable { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView ReportTable { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView textfield1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView textfield2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView textfield3 { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (MyPager != null) {
                MyPager.Dispose ();
                MyPager = null;
            }

            if (MyScroll != null) {
                MyScroll.Dispose ();
                MyScroll = null;
            }

            if (MyView != null) {
                MyView.Dispose ();
                MyView = null;
            }

            if (ProgressTable != null) {
                ProgressTable.Dispose ();
                ProgressTable = null;
            }

            if (ReportTable != null) {
                ReportTable.Dispose ();
                ReportTable = null;
            }

            if (textfield1 != null) {
                textfield1.Dispose ();
                textfield1 = null;
            }

            if (textfield2 != null) {
                textfield2.Dispose ();
                textfield2 = null;
            }

            if (textfield3 != null) {
                textfield3.Dispose ();
                textfield3 = null;
            }
        }
    }
}