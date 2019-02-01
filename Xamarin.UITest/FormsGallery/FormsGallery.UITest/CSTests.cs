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
    public class CSTests : HelperMethods
    {
        public CSTests(Platform platform)
        {
            this.platform = platform;
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void ViewsThatDisplayCollections()
        {
            // Picker
            OpenPage("Picker");
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

            // ListView
            OpenPage("ListView");
            app.Tap("Bob");
            app.Screenshot("selected Bob");
            // ScrollTo ("Down")
            if (platform == Platform.iOS)
            {
                app.ScrollTo("Timothy");
            } else app.ScrollDownTo("Timothy"); // ScrollTo broken on Android
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

            // TableView for a menu
            OpenPage("TableView for a menu");
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

            // TableView for a form
            OpenPage("TableView for a form");
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

        [Test]
        public void Cells()
        {
            // TextCell
            OpenPage("TextCell");
            app.Back();

            // ImageCell
            OpenPage("ImageCell");
            app.Back();

            // SwitchCell
            OpenPage("SwitchCell");
            if (platform == Platform.Android)
            {
                app.Tap(x => x.Class("Switch"));
            }
            else app.Tap(x => x.Class("UISwitch"));
            app.Screenshot("Flipped switch");
            app.Back();

            // EntryCell
            OpenPage("EntryCell");
            app.EnterText("Type text here", "This is an Entry Cell");
            app.Screenshot("Text entered into Entry Cell");
            app.DismissKeyboard();
            app.Screenshot("Keyboard Dismissed");
            app.Back();
        }

        [Test]
        public void LayoutsWithSingleContent()
        {
            // ContentView
            OpenPage("ContentView");
            app.Back();

            // Frame
            OpenPage("Frame");
            app.Back();

            // ScrollView
            OpenPage("ScrollView");
            app.ScrollDown();
            app.Screenshot("Scrolled down");
            app.ScrollUp();
            app.Screenshot("Scrolled back up");
            app.Back();
        }

        [Test]
        public void LayoutsWithMultipleChildren()
        {
            // StackLayout
            OpenPage("StackLayout");
            app.Back();

            // AbsoluteLayout
            OpenPage("AbsoluteLayout");
            app.Screenshot("Additional screenshot to catch them moving");
            app.Back();

            // Grid
            OpenPage("Grid");
            app.Back();

            // RelativeLayout
            OpenPage("RelativeLayout");
            app.Back();

            // FlexLayout
            OpenPage("FlexLayout");
            // Right to left
            app.SwipeRightToLeft();
            app.Screenshot("Swiped right to left");
            // Left to right
            app.SwipeLeftToRight();
            app.Screenshot("Swiped left to right");
            // Down
            app.ScrollDown();
            app.Screenshot("Scrolled Down");
            // Up
            app.ScrollUp();
            app.Screenshot("Scrolled Up");
            app.Back();
        }

        [Test]
        public void Pages()
        {
            OpenPage("ContentPage");
            app.Back();

            // Navigation Page
            OpenPage("NavigationPage");
            // Label
            app.Tap(" Go to Label Demo Page ");
            app.Screenshot("Open Label Demo");
            app.Back();
            // Image
            app.Tap(" Go to Image Demo Page ");
            app.Screenshot("Open Image Demo");
            app.Back();
            // BoxView
            app.Tap(" Go to BoxView Demo Page ");
            app.Screenshot("Open BoxView Demo");
            app.Back();
            // WebView
            app.Tap(" Go to WebView Demo Page ");
            app.Screenshot("Open WebView Demo");
            app.Back();
            // Back to main menu
            app.Back();

            // MasterDetailPage
            OpenPage("MasterDetailPage");
            app.SwipeLeftToRight();
            app.Back();

            // TabbedPage
            OpenPage("TabbedPage");
            // Green
            app.Tap("Green");
            app.Screenshot("Green");
            // Blue
            app.Tap("Blue");
            app.Screenshot("Blue");
            // Yellow
            app.Tap("Yellow");
            app.Screenshot("Yellow");
            // Red
            app.Tap("Red");
            app.Screenshot("Red");
            app.Back();


            OpenPage("CarouselPage");
            // Right to left
            app.SwipeRightToLeft();
            app.Screenshot("Swipe1");
            app.SwipeRightToLeft();
            app.Screenshot("Swipe2");
            app.SwipeRightToLeft();
            app.Screenshot("Swipe3");
            app.SwipeRightToLeft();
            app.Screenshot("Swipe4");
            app.SwipeRightToLeft();
            app.Screenshot("Swiped right to left 5 times");
            // Left to right
            app.SwipeLeftToRight();
            app.Screenshot("Swipe1");
            app.SwipeLeftToRight();
            app.Screenshot("Swipe2");
            app.SwipeLeftToRight();
            app.Screenshot("Swipe3");
            app.SwipeLeftToRight();
            app.Screenshot("Swipe4");
            app.SwipeLeftToRight();
            app.Screenshot("Swiped left to right 5 times");
            app.Back();
        }
    }
}
