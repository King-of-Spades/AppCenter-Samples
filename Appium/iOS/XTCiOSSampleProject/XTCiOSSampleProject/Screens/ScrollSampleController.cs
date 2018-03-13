using System;

using Foundation;
using UIKit;

namespace XTCiOSSampleProject
{
	public partial class ScrollSampleController : UITableViewController
	{
		public class TableSource : UITableViewSource
		{
			const int NUMBER_OF_ROWS = 50;
			const string cellIdentifier = "TableCell";

			public override nint RowsInSection (UITableView tableview, nint section)
			{
				return NUMBER_OF_ROWS;
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = (NestedLabelTableViewCell)tableView.DequeueReusableCell (cellIdentifier);
				// if there are no cells to reuse, create a new one
				if (cell == null) {
					cell = new NestedLabelTableViewCell (UITableViewCellStyle.Default, cellIdentifier);
				}

                if (indexPath.Row == 0)
                {
                    cell.UpdateCell("Top Text");
                }
                else if (indexPath.Row == NUMBER_OF_ROWS - 1)
                {
                    cell.UpdateCell("Bottom Text");
                }
                else
                {
                    cell.UpdateCell("Large Text");
                }

				return cell;
			}
		}

		public ScrollSampleController() : base(UITableViewStyle.Plain)
		{
			Title = "Scroll Sample";
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();

			TableView.Source = new TableSource ();
		}
	}
}
