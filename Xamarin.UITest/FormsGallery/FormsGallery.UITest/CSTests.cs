using System;
using System.IO;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace FormsGallery.UITest
{
    //[TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class CSTests
    {
        IApp app;
        Platform platform;

        public void openPage(string page)
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
        public void viewsForPresentation()
        {
            app.Screenshot("Views for presentation");

            openPage("Label");
            app.Back();

            openPage("Image");
            app.Back();

            openPage("BoxView");
            app.Back();

            openPage("WebView");
            app.Back();

            openPage("OpenGLView");
            app.Back();

            openPage("Map");
            app.Back();
        }

        [Test]
        public void viewsThatInitiateCommands()
        {
            app.ScrollDownTo("VIEWS THAT INITIATE COMMANDS");
            app.Screenshot("Scrolled down to Views that initiate commands");

            // Button page
            openPage("Button");
            app.Tap("Click Me!");
            app.Screenshot("Tapped Button");
            app.Back();

            // Image Button page
            openPage("ImageButton");
            app.Tap("XamarinLogo");
            app.Screenshot("Tapped Button");
            app.Back();

            // Search page
            openPage("SearchBar");
            app.Tap("Xamarin.Forms Property");
            app.EnterText("Page");
            app.PressEnter();
            app.Screenshot("Search query entered & result");

            app.Tap("Xamarin.Forms Property");
            app.Tap("Clear text");
            app.Screenshot("Old query deleted using X");

            app.Tap("Xamarin.Forms Property");
            app.EnterText("Label");
            app.Screenshot("New query ready");
            app.Tap("Cancel");
            app.Screenshot("Old query cleared using 'Cancel'");

            app.Tap("Xamarin.Forms Property");
            app.EnterText("View");
            app.ClearText();
            app.Screenshot("New query canceled using 'ClearText' method");
            app.Back();
        }

        [Test]
        public void viewsForSettingValues()
        {
            app.ScrollDownTo("VIEWS FOR SETTING VALUES");
            app.Screenshot("Scrolled down to Views for setting values");

            openPage("Slider (double)");


        }
    }
}
