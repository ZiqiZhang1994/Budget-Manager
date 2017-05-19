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
    [Register ("ProgressTableCell")]
    partial class ProgressTableCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIProgressView progressBar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel total { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel type { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (progressBar != null) {
                progressBar.Dispose ();
                progressBar = null;
            }

            if (total != null) {
                total.Dispose ();
                total = null;
            }

            if (type != null) {
                type.Dispose ();
                type = null;
            }
        }
    }
}