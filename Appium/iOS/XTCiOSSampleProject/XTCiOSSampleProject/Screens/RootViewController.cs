using System;
using UIKit;

namespace XTCiOSSampleProject
{
	public partial class RootViewController : UIViewController
	{
		public RootViewController () : base("RootViewController", null)
		{
			Title = "XTC iOS Sample";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			webViewButton.TouchUpInside += (object sender, EventArgs e) => NavigationController.PushViewController (new WebViewSampleController (), true);
			datePickerButton.TouchUpInside += (object sender, EventArgs e) => NavigationController.PushViewController (new DatePickerSampleController (), true);
			scrollScreenButton.TouchUpInside += (object sender, EventArgs e) => NavigationController.PushViewController (new ScrollSampleController (), true);
			directionalSwipeMeasurerButton.TouchUpInside += (object sender, EventArgs e) => NavigationController.PushViewController (new DirectionalSwipeSampleController (), true);
			viewsSampleButton.TouchUpInside += (object sender, EventArgs e) => NavigationController.PushViewController (new ViewsSampleController (), true);
			viewDataButton.TouchUpInside += (object sender, EventArgs e) => NavigationController.PushViewController (new ViewDataSampleController (), true);
			orientationsButton.TouchUpInside += (object sender, EventArgs e) => NavigationController.PushViewController (new OrientationsSampleController (), true);
            tapSample.TouchUpInside += (sender, e) => NavigationController.PushViewController(new TapSampleController(), true);
            location.TouchUpInside += (sender, e) => NavigationController.PushViewController(new LocationSampleController(), true);
            webViewSwipeButton.TouchUpInside += (sender, e) => NavigationController.PushViewController(new WebViewSwipeSampleController(), true);
		}
	}
}

