using System;
using Foundation;
using UIKit;

namespace XTCiOSSampleProject
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);                     
			window.RootViewController = new UINavigationController (new RootViewController ());
			window.MakeKeyAndVisible ();
			return true;
		}

		public override void OnResignActivation (UIApplication application)
		{
		}

		public override void DidEnterBackground (UIApplication application)
		{
		}

        public override void WillEnterForeground (UIApplication application)
		{
		}

        public override void WillTerminate (UIApplication application)
		{
		}
	}
}

