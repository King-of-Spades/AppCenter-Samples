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
    public class CSTests
    {
        IApp app;
        Platform platform;

        public void OpenPage(string page)
        {
            Console.WriteLine("Attempting to open " + page);
            app.WaitForElement("C# Pages");
            app.ScrollDownTo(page);
            app.Screenshot("Scrolled To" + page);
            app.Tap(x => x.Marked(page));
            app.Screenshot(page);
        }

        public CSTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void ScrollToDemo()
        {

            // ListView
            OpenPage("ListView");
            app.Tap("Bob");
            app.Screenshot("selected Bob");
            // ScrollTo ("Down")
            app.ScrollTo("Timothy");
            app.Tap("Timothy");
            app.Screenshot("ScrollTo (Down) then tap Timothy");
            //ScrollTo (Up)
            app.ScrollTo("Freddie");
            app.Tap("Freddie");
            app.Screenshot("ScrollTo (Up) then tap Freddie");
            app.Back();
        }
    }
}
