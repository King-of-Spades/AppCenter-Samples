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
    [Register ("OrientationsSampleController")]
    partial class OrientationsSampleController
    {
        [Outlet]
        UIKit.UIButton landscapeLeftButton { get; set; }


        [Outlet]
        UIKit.UIButton landscapeRightButton { get; set; }


        [Outlet]
        UIKit.UIButton portraitButton { get; set; }


        [Outlet]
        UIKit.UIButton portraitUpsideDownButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (landscapeLeftButton != null) {
                landscapeLeftButton.Dispose ();
                landscapeLeftButton = null;
            }

            if (landscapeRightButton != null) {
                landscapeRightButton.Dispose ();
                landscapeRightButton = null;
            }

            if (portraitButton != null) {
                portraitButton.Dispose ();
                portraitButton = null;
            }

            if (portraitUpsideDownButton != null) {
                portraitUpsideDownButton.Dispose ();
                portraitUpsideDownButton = null;
            }
        }
    }
}