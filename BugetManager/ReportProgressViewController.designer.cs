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
        UIKit.UIView ProgressTable { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView ReportTable { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ProgressTable != null) {
                ProgressTable.Dispose ();
                ProgressTable = null;
            }

            if (ReportTable != null) {
                ReportTable.Dispose ();
                ReportTable = null;
            }
        }
    }
}