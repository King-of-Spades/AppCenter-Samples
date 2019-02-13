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
    public class ViewsThatDisplayCollections : HelperMethods
    {
        public ViewsThatDisplayCollections(Platform platform)
        {
            this.platform = platform;
        }

        [Test]
        public void Picker()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("Picker", i);
                app.Tap("Color");
                // Scroll through options on iOS
                // app.Tap(x => x.Class("UILabel").Index(N)); 

                // Fuchsia
                app.Tap("Fuchsia");
                app.Screenshot("picked Fuchsia");
                app.Tap("Fuchsia"); // Does nothing on iOS, reopens Android menu

                // Lime
                app.Tap("Lime");
                app.Screenshot("picked Lime");
                app.Tap("Lime");

                // Gray
                app.Tap("Gray");
                app.Screenshot("picked Gray");
                app.Tap("Gray");

                // Finishes iOS selection
                if (platform == Platform.iOS)
                {
                    app.Tap("Done");
                    app.Screenshot("confirmed Gray");
                }
                else app.Tap("Cancel");
                app.Back();
            }

        }

        [Test]
        public void ListView()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("ListView", i);
                app.Tap("Bob");
                app.Screenshot("selected Bob");

                // ScrollTo ("Down")
                if (platform == Platform.iOS)
                {
                    app.ScrollTo("Timothy");
                }
                else app.ScrollDownTo("Timothy"); // ScrollTo broken on Android
                app.Tap("Timothy");
                app.Screenshot("ScrollTo (Down) then tap Timothy");

                // ScrollUp
                app.ScrollUp();
                app.Tap("Greta");
                app.Screenshot("ScrollUp then tap Greta");

                // ScrollDown
                app.ScrollDown();
                app.Tap("Wendy");
                app.Screenshot("ScrollDown then tap Wendy");

                // ScrollUpTo
                app.ScrollUpTo("David");
                app.Tap("David");
                app.Screenshot("ScrollUpTo then tap David");

                // ScrollDownTo
                app.ScrollDownTo("Xavier");
                app.Tap("Xavier");
                app.Screenshot("ScrollDownTo then tap Xavier");

                //ScrollTo (Up)
                if (platform == Platform.iOS)
                {
                    app.ScrollTo("Freddie");
                }
                else app.ScrollUpTo("Freddie"); // ScrollTo broken on Android
                app.Tap("Freddie");
                app.Screenshot("ScrollTo (Up) then tap Freddie");
                app.Back();
            }
        }

        [Test]
        public void TableViewMenu()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("TableView for a menu", i);

                // Nested views
                app.Tap("Label");
                app.Back();
                app.Tap("Image");
                app.Back();
                app.Tap("BoxView");
                app.Back();
                app.Tap("WebView");
                app.Back();
     
                // Finished
                app.Back();
            }
        }

        [Test]
        public void TableViewForm()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("TableView for a form", i);

                // Switch Cell
                if (platform == Platform.iOS)
                {
                    app.Tap(x => x.Class("UISwitch"));
                }
                else app.Tap(x => x.Class("Switch"));
                app.Screenshot("Flipped switch");
             
                // Entry Cell
                app.EnterText("Type text here", "This is an Entry Cell");
                app.Screenshot("Text entered into Entry Cell");
                app.DismissKeyboard();
                app.Screenshot("Keyboard Dismissed");
                app.Back();
            }
        }
    }
}
