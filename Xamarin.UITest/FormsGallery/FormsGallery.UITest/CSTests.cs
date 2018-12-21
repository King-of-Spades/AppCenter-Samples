using System;
using System.IO;
using System.Linq;
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

        public void pageTest(string page)
        {
            app.Tap(x => x.Marked(page));
            app.Flash(x => x.Marked(page + " Demo"));
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
        public void Label()
        {
            pageTest("Label");
            app.Back();
        }

        [Test]
        public void Image()
        {
            pageTest("Image");
            app.Back();
        }
    }
}
