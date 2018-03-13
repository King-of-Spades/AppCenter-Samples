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
    [Register ("ViewDataSampleController")]
    partial class ViewDataSampleController
    {
        [Outlet]
        UIKit.UILabel checkboxLabel { get; set; }


        [Outlet]
        UIKit.UILabel dateLabel { get; set; }


        [Outlet]
        UIKit.UILabel radioSelectedLabel { get; set; }


        [Outlet]
        UIKit.UILabel seekBarProgressLabel { get; set; }


        [Outlet]
        UIKit.UILabel timeLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (checkboxLabel != null) {
                checkboxLabel.Dispose ();
                checkboxLabel = null;
            }

            if (dateLabel != null) {
                dateLabel.Dispose ();
                dateLabel = null;
            }

            if (radioSelectedLabel != null) {
                radioSelectedLabel.Dispose ();
                radioSelectedLabel = null;
            }

            if (seekBarProgressLabel != null) {
                seekBarProgressLabel.Dispose ();
                seekBarProgressLabel = null;
            }

            if (timeLabel != null) {
                timeLabel.Dispose ();
                timeLabel = null;
            }
        }
    }
}