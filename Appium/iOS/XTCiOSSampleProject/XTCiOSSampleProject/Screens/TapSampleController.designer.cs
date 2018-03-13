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
    [Register ("TapSampleController")]
    partial class TapSampleController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel gestureTypeResult { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton pressMe { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel timeHeldResult { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel touchEndedResult { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel touchStartedResult { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (gestureTypeResult != null) {
                gestureTypeResult.Dispose ();
                gestureTypeResult = null;
            }

            if (pressMe != null) {
                pressMe.Dispose ();
                pressMe = null;
            }

            if (timeHeldResult != null) {
                timeHeldResult.Dispose ();
                timeHeldResult = null;
            }

            if (touchEndedResult != null) {
                touchEndedResult.Dispose ();
                touchEndedResult = null;
            }

            if (touchStartedResult != null) {
                touchStartedResult.Dispose ();
                touchStartedResult = null;
            }
        }
    }
}