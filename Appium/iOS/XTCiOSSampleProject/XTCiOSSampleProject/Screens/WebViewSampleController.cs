using System;

using Foundation;
using UIKit;
using System.IO;

namespace XTCiOSSampleProject
{
	public partial class WebViewSampleController : UIViewController
	{
		public WebViewSampleController () : base ("WebViewSampleController", null)
		{
			Title = "Web View Sample";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			string basePath = Path.Combine (NSBundle.MainBundle.BundlePath, "Content/");
			string htmlFilePath = Path.Combine (basePath, "web_view.html");
			this.webView.LoadData (File.ReadAllText (htmlFilePath), "text/html", "UTF-8", new NSUrl(basePath, true));
		}
	}
}
