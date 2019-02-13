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
    public class LayoutsWithSingleContent : HelperMethods
    {
        public LayoutsWithSingleContent(Platform platform)
        {
            this.platform = platform;
        }

        [Test]
        public void ContentView()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("ContentView", i);
                app.Back();
            }
        }

        [Test]
        public void Frame()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("Frame", i);
                app.Back();
            }
        }

        [Test]
        public void ScrollView()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("ScrollView", i);
                app.ScrollDown();
                app.Screenshot("Scrolled down");
                app.ScrollUp();
                app.Screenshot("Scrolled back up");
                app.Back();
            }
        }
    }
}
