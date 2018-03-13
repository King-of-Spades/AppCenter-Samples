// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace XTCiOSSampleProject
{
    [Register ("ViewsSampleController")]
    partial class ViewsSampleController
    {
        [Outlet]
        UIKit.UIButton cancelButton { get; set; }


        [Outlet]
        UIKit.UISwitch checkbox { get; set; }


        [Outlet]
        UIKit.UIButton saveButton { get; set; }


        [Outlet]
        UIKit.UISegmentedControl segmentedControl { get; set; }


        [Outlet]
        UIKit.UISlider slider { get; set; }


        [Outlet]
        UIKit.UILabel sliderLabel { get; set; }


        [Outlet]
        UIKit.UITableView table { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (cancelButton != null) {
                cancelButton.Dispose ();
                cancelButton = null;
            }

            if (checkbox != null) {
                checkbox.Dispose ();
                checkbox = null;
            }

            if (saveButton != null) {
                saveButton.Dispose ();
                saveButton = null;
            }

            if (segmentedControl != null) {
                segmentedControl.Dispose ();
                segmentedControl = null;
            }

            if (slider != null) {
                slider.Dispose ();
                slider = null;
            }

            if (sliderLabel != null) {
                sliderLabel.Dispose ();
                sliderLabel = null;
            }

            if (table != null) {
                table.Dispose ();
                table = null;
            }
        }
    }
}