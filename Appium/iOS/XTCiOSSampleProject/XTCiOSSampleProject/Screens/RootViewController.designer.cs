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
    [Register ("RootViewController")]
    partial class RootViewController
    {
        [Outlet]
        UIKit.UIButton datePickerButton { get; set; }


        [Outlet]
        UIKit.UIButton directionalSwipeMeasurerButton { get; set; }


        [Outlet]
        UIKit.UIButton inputWithSpellCheckerButton { get; set; }


        [Outlet]
        UIKit.UIButton orientationsButton { get; set; }


        [Outlet]
        UIKit.UIButton scrollScreenButton { get; set; }


        [Outlet]
        UIKit.UIButton viewDataButton { get; set; }


        [Outlet]
        UIKit.UIButton viewsSampleButton { get; set; }


        [Outlet]
        UIKit.UIButton webViewButton { get; set; }

        [Outlet]
        UIKit.UIButton webViewSwipeButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton crashOnPurposeButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton location { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton tapSample { get; set; }

        [Action ("CrashOnPurposeButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CrashOnPurposeButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (crashOnPurposeButton != null) {
                crashOnPurposeButton.Dispose ();
                crashOnPurposeButton = null;
            }

            if (datePickerButton != null) {
                datePickerButton.Dispose ();
                datePickerButton = null;
            }

            if (directionalSwipeMeasurerButton != null) {
                directionalSwipeMeasurerButton.Dispose ();
                directionalSwipeMeasurerButton = null;
            }

            if (inputWithSpellCheckerButton != null) {
                inputWithSpellCheckerButton.Dispose ();
                inputWithSpellCheckerButton = null;
            }

            if (location != null) {
                location.Dispose ();
                location = null;
            }

            if (orientationsButton != null) {
                orientationsButton.Dispose ();
                orientationsButton = null;
            }

            if (scrollScreenButton != null) {
                scrollScreenButton.Dispose ();
                scrollScreenButton = null;
            }

            if (tapSample != null) {
                tapSample.Dispose ();
                tapSample = null;
            }

            if (viewDataButton != null) {
                viewDataButton.Dispose ();
                viewDataButton = null;
            }

            if (viewsSampleButton != null) {
                viewsSampleButton.Dispose ();
                viewsSampleButton = null;
            }

            if (webViewButton != null) {
                webViewButton.Dispose ();
                webViewButton = null;
            }

            if (webViewSwipeButton != null) {
                webViewSwipeButton.Dispose ();
                webViewSwipeButton = null;
            }
        }
    }
}