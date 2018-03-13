using UIKit;
using CoreGraphics;

namespace XTCiOSSampleProject
{
    public class NestedLabelTableViewCell : UITableViewCell
    {
        UIView _outerContainer;
        UIView _innerContainer;
        UILabel _label;

        public NestedLabelTableViewCell(UITableViewCellStyle style, string reuseIdentifier) : base(style, reuseIdentifier)
        {
            _outerContainer = new UIView();
            _innerContainer = new UIView();
            _label = new UILabel();

            ContentView.AddSubview(_outerContainer);
            _outerContainer.AddSubview(_innerContainer);
            _innerContainer.AddSubview(_label);
        }

        public void UpdateCell(string text)
        {
            _label.Text = text;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            var frame = new CGRect(0, 0, Frame.Width, Frame.Height);

            _outerContainer.Frame = frame;
            _innerContainer.Frame = frame;
            _label.Frame = frame;
        }
    }
}
