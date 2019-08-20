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
    public class Pages : HelperMethods
    {
        public Pages(Platform platform)
        {
            this.platform = platform;
        }

        [Category("ContentPage")]
        [Test]
        public void ContentPage()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("ContentPage", i);
                app.Back();
            }
        }

        [Test]
        public void NavigationPage()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("NavigationPage", i);
                // Label
                app.Tap(" Go to Label Demo Page ");
                app.Screenshot("Open Label Demo");
                app.Back();
                // Image
                app.Tap(" Go to Image Demo Page ");
                app.Screenshot("Open Image Demo");
                app.Back();
                // BoxView
                app.Tap(" Go to BoxView Demo Page ");
                app.Screenshot("Open BoxView Demo");
                app.Back();
                // WebView
                app.Tap(" Go to WebView Demo Page ");
                app.Screenshot("Open WebView Demo");
                app.Back();
                // Back to main menu                
                app.Back();
            }
        }

        [Test]
        public void MasterDetailPage()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("MasterDetailPage", i);
                app.SwipeLeftToRight();
                app.Back();
            }
        }

        [Test]
        public void TabbedPage()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("TabbedPage", i);

                // Green
                app.Tap("Green");
                app.Screenshot("Green");

                // Blue
                app.Tap("Blue");
                app.Screenshot("Blue");

                // Yellow
                app.Tap("Yellow");
                app.Screenshot("Yellow");

                // Red
                app.Tap("Red");
                app.Screenshot("Red");
                app.Back();
            }
        }

        [Test]
        public void CarouselPage()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("CarouselPage", i);

                // Right to left
                app.SwipeRightToLeft();
                app.Screenshot("Swipe1");
                app.SwipeRightToLeft();
                app.Screenshot("Swipe2");
                app.SwipeRightToLeft();
                app.Screenshot("Swipe3");
                app.SwipeRightToLeft();
                app.Screenshot("Swipe4");
                app.SwipeRightToLeft();
                app.Screenshot("Swiped right to left 5 times");

                // Left to right
                app.SwipeLeftToRight();
                app.Screenshot("Swipe1");
                app.SwipeLeftToRight();
                app.Screenshot("Swipe2");
                app.SwipeLeftToRight();
                app.Screenshot("Swipe3");
                app.SwipeLeftToRight();
                app.Screenshot("Swipe4");
                app.SwipeLeftToRight();
                app.Screenshot("Swiped left to right 5 times");
                app.Back();
            }
        }
    }
}
