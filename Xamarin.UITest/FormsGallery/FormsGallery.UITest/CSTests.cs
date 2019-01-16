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
        public void FacebookValidLogin()
        {
            // read datafile line by line
            StreamReader stream = new StreamReader(EmbeddedResources.ResourceLoader.GetEmbeddedResourceStream("testDataFile.txt"));
            // Dummy account
            string username = stream.ReadLine();
            string password = stream.ReadLine();

            OpenPage("WebView");
            app.EnterText(x => x.Css("input").Index(0), username);
            app.Tap(x => x.Css("input").Index(1));
            app.EnterText(password);
            app.Screenshot("Entered Username & password");
            app.Tap(x => x.Css("button"));
            app.Screenshot("Tapped login button");
        }

        [Test]
        public void FacebookInvalidEmail()
        {
            // Dummy account
            StreamReader stream = new StreamReader(EmbeddedResources.ResourceLoader.GetEmbeddedResourceStream("testDataFile.txt"));
            // Dummy account
            string username = "InvalidEmail";
            stream.ReadLine(); // skip valid email
            string password = stream.ReadLine();

            OpenPage("WebView");
            app.EnterText(x => x.Css("input").Index(0), username);
            app.Tap(x => x.Css("input").Index(1));
            app.EnterText(password);
            app.Tap(x => x.Css("button"));
            app.Screenshot("Tapped login button");
        }

        [Test]
        public void FacebookInvalidPassword()
        {
            // Dummy account
            // read datafile line by line
            StreamReader stream = new StreamReader(EmbeddedResources.ResourceLoader.GetEmbeddedResourceStream("testDataFile.txt"));
            // Dummy account
            string username = stream.ReadLine();
            string password = "InvalidPassword";


            OpenPage("WebView");
            app.EnterText(x => x.Css("input").Index(0), username);
            app.Tap(x => x.Css("input").Index(1));
            app.EnterText(password);
            app.Tap(x => x.Css("button"));
            app.Screenshot("Tapped login button");
        }

        [Test]
        public void WebViewEnterTextBug() // bug on iOS simulator, works as expected on Android
        {
            // read datafile line by line
            StreamReader stream = new StreamReader(EmbeddedResources.ResourceLoader.GetEmbeddedResourceStream("testDataFile.txt"));
            // Dummy account
            string username = stream.ReadLine();
            string password = stream.ReadLine();


            OpenPage("WebView");
            app.EnterText(x => x.Css("input").Index(0), username);
            app.EnterText(x => x.Css("input").Index(1), password);
            app.DismissKeyboard();
            app.Screenshot("Text entered before instead of after changing selection");
        }
    }
}
