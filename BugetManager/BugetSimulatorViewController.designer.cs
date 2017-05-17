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
    [Register ("BugetSimulatorViewController")]
    partial class BugetSimulatorViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSave { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblMonthBudget { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblRemaningBudget { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTotalCostPlanned { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTotalCostThisMonth { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tablePlannedCost { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtname { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtValue { get; set; }

        [Action ("BtnSave_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSave_TouchUpInside (UIKit.UIButton sender);

        [Action ("UIButton2001_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton2001_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnSave != null) {
                btnSave.Dispose ();
                btnSave = null;
            }

            if (lblMonthBudget != null) {
                lblMonthBudget.Dispose ();
                lblMonthBudget = null;
            }

            if (lblRemaningBudget != null) {
                lblRemaningBudget.Dispose ();
                lblRemaningBudget = null;
            }

            if (lblTotalCostPlanned != null) {
                lblTotalCostPlanned.Dispose ();
                lblTotalCostPlanned = null;
            }

            if (lblTotalCostThisMonth != null) {
                lblTotalCostThisMonth.Dispose ();
                lblTotalCostThisMonth = null;
            }

            if (tablePlannedCost != null) {
                tablePlannedCost.Dispose ();
                tablePlannedCost = null;
            }

            if (txtname != null) {
                txtname.Dispose ();
                txtname = null;
            }

            if (txtValue != null) {
                txtValue.Dispose ();
                txtValue = null;
            }
        }
    }
}