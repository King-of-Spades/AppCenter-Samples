using System;

using Foundation;
using UIKit;

namespace XTCiOSSampleProject
{
	public partial class DatePickerSampleController : UIViewController
	{
		public DatePickerSampleController () : base ("DatePickerSampleController", null)
		{
			Title = "Date Picker";
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();

			this.cancelButton.TouchUpInside += (object sender, EventArgs e) => NavigationController.PopViewController(true);
			this.saveButton.TouchUpInside += (object sender, EventArgs e) => {
				Settings.PickedTime = (System.DateTime) this.datePicker.Date;
				NavigationController.PopViewController (true);
			};
		}
	}
}
