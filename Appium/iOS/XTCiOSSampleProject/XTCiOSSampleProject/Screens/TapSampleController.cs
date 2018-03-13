using System;
using System.Diagnostics;
using Foundation;
using UIKit;

namespace XTCiOSSampleProject
{
	public partial class TapSampleController : UIViewController
	{
        Stopwatch timer;

		public TapSampleController () : base ("TapSampleController", null)
		{
			Title = "TapSampleController";
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();

            this.pressMe.TouchDown += (sender, e) =>
            {
                timer = Stopwatch.StartNew();
                this.gestureTypeResult.Text = "Tap";
                this.touchStartedResult.Text = DateTime.Now.ToString();
            };

            this.pressMe.TouchUpInside += (sender, e) =>
            {
                timer.Stop();
                this.touchEndedResult.Text = DateTime.Now.ToString();
                this.timeHeldResult.Text = $"{timer.Elapsed.ToString()}";
            };

            this.pressMe.TouchDownRepeat += (sender, e) => 
            {
                timer.Stop();
                this.touchEndedResult.Text = DateTime.Now.ToString();
                this.gestureTypeResult.Text = "Double Tap";
            };
		}
	}
}
