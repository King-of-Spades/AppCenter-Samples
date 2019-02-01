using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace FormsGallery.UITest
{
    public class HelperMethods
    {

        public IApp app;
        public Platform platform;

        public void JustOpen(string page) // used if no tasks need to be performed on page
        {
            OpenPage(page, 0); 
            app.Back();
            OpenPage(page, 1);
        }

        public void OpenPage(string page)
        {
            OpenPage(page, 0); // Temporary while I update the approach
        }

        public void OpenPage(string page, int pageType)
        {
            if (pageType == 0)
            {
                app.Tap("C# Pages");
                app.Screenshot("C# " + page + " page");
            }
            else
            {
                app.Tap("XAML Pages");
                app.Screenshot("XAML " + page + " page");
            }
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