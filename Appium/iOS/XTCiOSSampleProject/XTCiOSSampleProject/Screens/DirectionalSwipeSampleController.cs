using System;

using Foundation;
using UIKit;

namespace XTCiOSSampleProject
{
	public partial class DirectionalSwipeSampleController : UIViewController
	{
		public DirectionalSwipeSampleController () : base ("DirectionalSwipeSampleController", null)
		{
			Title = "Directional Swipe";
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();

			rightSwipeGestureRecognizer.AddTarget (() => { label.Text = "Left Swipe"; });
			leftSwipeGestureRecognizer.AddTarget (() => { label.Text = "Right Swipe"; });
			upSwipeGestureRecognizer.AddTarget (() => { label.Text = "Down Swipe"; });
			downSwipeGestureRecognizer.AddTarget (() => { label.Text = "Up Swipe"; });
		}
	}
}
