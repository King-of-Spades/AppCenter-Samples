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
            app.Back();

            // Android: Map not displayed & SetLocation not working
            // iOS: Location not changing
            app.Device.SetLocation(37.79762, -122.40181);
            app.Screenshot("Xamarin HQ defined with 5 decmial points");
            //app.Device.SetLocation(27.9881, 86.9250);
            //app.Screenshot("Mt. Everest defined with 4 decimal points");
            //app.Device.SetLocation(51.507, -0.128);
            //app.Screenshot("London defined with 3 decimal points");
            //app.Device.SetLocation(40.71, -74.01);
            //app.Screenshot("New York defined with 2 decmial points");
            //app.Device.SetLocation(48.9, 2.4);
            //app.Screenshot("Paris defined with 1 decimal point");
            //app.Device.SetLocation(-13, -72);
            //app.Screenshot("Machu Picchu defined with 0 decimal points");
            //app.Back();

            OpenPage("Map", 1);
            app.Back();
        }
    }
}
