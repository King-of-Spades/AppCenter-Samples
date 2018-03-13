using System;

using Foundation;
using UIKit;
using System.IO;

namespace XTCiOSSampleProject
{
	public partial class WebViewSwipeSampleController : UIViewController
	{
		public WebViewSwipeSampleController () : base ("WebViewSwipeSampleController", null)
		{
			Title = "Web View Sample";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			string basePath = Path.Combine (NSBundle.MainBundle.BundlePath, "Content/");
			string htmlFilePath = Path.Combine (basePath, "swipe_page.html");
			this.webView.LoadData (File.ReadAllText (htmlFilePath), "text/html", "UTF-8", new NSUrl(basePath, true));
		}
	}
}
