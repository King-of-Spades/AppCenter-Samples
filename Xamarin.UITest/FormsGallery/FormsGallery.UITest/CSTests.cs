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
    public class CSTests : HelperMethods
    {
        public CSTests(Platform platform)
        {
            this.platform = platform;
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }


        [Test]
        public void LayoutsWithSingleContent()
        {
            // ContentView
            OpenPage("ContentView");
            app.Back();

            // Frame
            OpenPage("Frame");
            app.Back();

            // ScrollView
            OpenPage("ScrollView");
            app.ScrollDown();
            app.Screenshot("Scrolled down");
            app.ScrollUp();
            app.Screenshot("Scrolled back up");
            app.Back();
        }

        [Test]
        public void LayoutsWithMultipleChildren()
        {
            // StackLayout
            OpenPage("StackLayout");
            app.Back();

            // AbsoluteLayout
            OpenPage("AbsoluteLayout");
            app.Screenshot("Additional screenshot to catch them moving");
            app.Back();

            // Grid
            OpenPage("Grid");
            app.Back();

            // RelativeLayout
            OpenPage("RelativeLayout");
            app.Back();

            // FlexLayout
            OpenPage("FlexLayout");
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
            app.Back();
        }
    }
}
