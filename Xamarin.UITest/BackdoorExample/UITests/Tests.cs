using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;


namespace backdoor.UITests
{
    [TestFixture (Platform.Android)]
    [TestFixture (Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests (Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest ()
        {
            app = AppInitializer.StartApp (platform);
        }

        [Test]
        public void WelcomeTextIsDisplayed ()
        {
            AppResult[] results = app.WaitForElement (c => c.Marked ("Welcome to Xamarin Forms!"));
            string backdoorValue = "Welcome";

            // Triggers Platform-specific Backdoor method in each respective app
            if (platform == Platform.iOS) {
                backdoorValue = app.Invoke ("BackdoorMethod:", // notice the colon :
                    "Running on iOS").ToString();
            } else if (platform == Platform.Android) {
                backdoorValue = app.Invoke ("BackdoorMethod", // notice no colon :
                    "Running on Android").ToString();
            }

            Console.WriteLine ("backdoorValue:" + backdoorValue);

            app.Screenshot (backdoorValue);
            Assert.IsTrue (backdoorValue.Contains("Executed Backdoor"));
            Assert.IsTrue (results.Any ());
        }
    }
}

