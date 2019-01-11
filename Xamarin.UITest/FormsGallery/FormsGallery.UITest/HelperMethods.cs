using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace FormsGallery.UITest
{
    public class HelperMethods
    {

        public IApp app;
        public Platform platform;

        public void OpenPage(string page, bool cspage=true)
        {
            if (cspage)
            {
                app.Tap("C# Pages");
            } else app.Tap("XAML Pages");
            app.ScrollDownTo(page);
            app.Screenshot("Scrolled Down To" + page);
            app.Tap(x => x.Marked(page));
            app.Screenshot(page);
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

    }
}