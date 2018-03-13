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
    [Register ("DirectionalSwipeSampleController")]
    partial class DirectionalSwipeSampleController
    {
        [Outlet]
        UIKit.UISwipeGestureRecognizer downSwipeGestureRecognizer { get; set; }


        [Outlet]
        UIKit.UILabel label { get; set; }


        [Outlet]
        UIKit.UISwipeGestureRecognizer leftSwipeGestureRecognizer { get; set; }


        [Outlet]
        UIKit.UISwipeGestureRecognizer rightSwipeGestureRecognizer { get; set; }


        [Outlet]
        UIKit.UISwipeGestureRecognizer upSwipeGestureRecognizer { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (downSwipeGestureRecognizer != null) {
                downSwipeGestureRecognizer.Dispose ();
                downSwipeGestureRecognizer = null;
            }

            if (label != null) {
                label.Dispose ();
                label = null;
            }

            if (leftSwipeGestureRecognizer != null) {
                leftSwipeGestureRecognizer.Dispose ();
                leftSwipeGestureRecognizer = null;
            }

            if (rightSwipeGestureRecognizer != null) {
                rightSwipeGestureRecognizer.Dispose ();
                rightSwipeGestureRecognizer = null;
            }

            if (upSwipeGestureRecognizer != null) {
                upSwipeGestureRecognizer.Dispose ();
                upSwipeGestureRecognizer = null;
            }
        }
    }
}