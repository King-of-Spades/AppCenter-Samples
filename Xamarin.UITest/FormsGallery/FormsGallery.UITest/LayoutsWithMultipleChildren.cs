using System;
using System.IO;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace FormsGallery.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class LayoutsWithMultipleChildren : HelperMethods
    {
        public LayoutsWithMultipleChildren(Platform platform)
        {
            this.platform = platform;
        }

        [Test]
        public void StackLayout()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("StackLayout", i);
                app.Back();
            }
        }

        [Test]
        public void AbsoluteLayout()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("AbsoluteLayout", i);
                app.Screenshot("Additional screenshot to catch them moving");
                app.Back();
            }
        }

        [Test]
        public void Grid()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("Grid", i);
                app.Back();
            }
        }

        [Test]
        public void RelativeLayout()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("RelativeLayout", i);
                app.Back();
            }
        }

        [Test]
        public void FlexLayout()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("FlexLayout", i);

                // Right to left
                app.SwipeRightToLeft();
                app.Screenshot("Swiped right to left");
                // Left to right
                app.SwipeLeftToRight();
                app.Screenshot("Swiped left to right");
                // Down
                app.ScrollDown();
                app.Screenshot("Scrolled Down");
                // Up
                app.ScrollUp();
                app.Screenshot("Scrolled Up");
                // end
                app.Back();
            }
        }
    }
}
