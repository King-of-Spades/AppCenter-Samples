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
    public class ViewsThatInitiateCommands : HelperMethods
    {
        public ViewsThatInitiateCommands(Platform platform)
        {
            this.platform = platform;
        }

        [Test]
        public void Button()
        {
            for (int i=0; i <= 1; i++)
            {
                OpenPage("Button", i);
                app.Tap("Click Me!");
                app.Screenshot("Tapped Button");
                app.Back();
            }

        }

        [Test]
        public void ImageButton()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("ImageButton", i);
                app.Tap("ImageButtonElement");
                app.Screenshot("Tapped Button");
                app.Back();
            }
        }


        [Test]
        public void SearchPage()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("SearchBar", i);
                app.Tap("Xamarin.Forms Property");
                app.EnterText("Page");
                app.PressEnter();
                app.Screenshot("Search query entered & result");
                app.Tap("Xamarin.Forms Property");
                if (platform == Platform.iOS)
                {
                    app.Tap("Clear text");
                }
                else app.Tap("Clear query");
                app.Screenshot("Old query deleted using X");
                if (platform == Platform.iOS)
                {
                    app.Tap("Xamarin.Forms Property");
                    app.EnterText("Label");
                    app.Screenshot("New query ready");
                    app.Tap("Cancel");
                    app.Screenshot("Old query cleared using 'Cancel'");
                }
                app.Tap("Xamarin.Forms Property");
                app.EnterText("View");
                app.ClearText();
                app.Screenshot("New query canceled using 'ClearText' method");
                if (platform == Platform.Android) { app.Back(); }
                app.Back();
            }
        }
    }
}
