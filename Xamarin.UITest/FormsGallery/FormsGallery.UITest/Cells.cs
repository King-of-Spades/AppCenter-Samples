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
    public class Cells : HelperMethods
    {
        public Cells(Platform platform)
        {
            this.platform = platform;
        }

        [Test]
        public void TextCell()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("TextCell", i);
                app.Back();
            }
        }

        [Test]
        public void ImageCell()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("ImageCell", i);
                app.Back();
            }
        }

        [Test]
        public void SwitchCell()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("SwitchCell", i);

                if (platform == Platform.Android)
                {
                    app.Tap(x => x.Class("Switch"));
                }
                else app.Tap(x => x.Class("UISwitch"));

                app.Screenshot("Flipped switch");
                app.Back();
            }
        }

        [Test]
        public void EntryCell()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("EntryCell", i);
                app.EnterText("Type text here", "This is an Entry Cell");
                app.Screenshot("Text entered into Entry Cell");
                app.DismissKeyboard();
                app.Screenshot("Keyboard Dismissed");
                app.Back();
            }
        }
    }
}
