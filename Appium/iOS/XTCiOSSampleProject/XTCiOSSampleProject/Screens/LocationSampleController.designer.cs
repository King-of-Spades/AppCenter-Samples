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
    [Register ("LocationSampleController")]
    partial class LocationSampleController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel latLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel locationEnabledLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lonLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (latLabel != null) {
                latLabel.Dispose ();
                latLabel = null;
            }

            if (locationEnabledLabel != null) {
                locationEnabledLabel.Dispose ();
                locationEnabledLabel = null;
            }

            if (lonLabel != null) {
                lonLabel.Dispose ();
                lonLabel = null;
            }
        }
    }
}