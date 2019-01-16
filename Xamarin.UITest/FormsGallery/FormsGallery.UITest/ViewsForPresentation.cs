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
    public class ViewsForPresentation : HelperMethods
    {
        public ViewsForPresentation(Platform platform)
        {
            this.platform = platform;
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void Label()
        {
            OpenPage("Label", 0);
            app.Back();

            OpenPage("Label", 1);
            app.Back();
        }


        [Test]
        public void Image()
        {
            OpenPage("Image", 0);
            app.Back();

            OpenPage("Image", 1);
            app.Back();
        }

        [Test]
        public void BoxView()
        {
            OpenPage("BoxView", 0);
            app.Back();

            OpenPage("BoxView", 1);
            app.Back();
        }

        [Test]
        public void WebView()
        {
            OpenPage("WebView", 0);
            app.Back();

            OpenPage("WebView", 1);
            app.Back();
        }

        [Test]
        public void OpenGLView()
        {
            OpenPage("OpenGLView", 0);
            app.Back();

            OpenPage("OpenGLView", 1);
            app.Back();
        }

        [Test]
        public void Map()
        {
            OpenPage("Map", 0);
            app.Repl();
            app.Back();

            OpenPage("Map", 1);
            app.Back();
        }
    }
}
