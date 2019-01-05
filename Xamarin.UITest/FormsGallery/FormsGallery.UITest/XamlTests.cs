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
    public class XamlTests
    {
        IApp app;
        Platform platform;

        public void OpenPage(string page)
        {
            app.WaitForElement("XAML Pages");
            app.ScrollDownTo(page);
            app.Screenshot("Scrolled To" + page);
            app.Tap(x => x.Marked(page));
            app.Screenshot(page);
        }

        public XamlTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
            app.Tap("XAML Pages");
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void ViewsForPresentation()
        {
            OpenPage("Label");
            app.Back();

            OpenPage("Image");
            app.Back();

            OpenPage("BoxView");
            app.Back();

            OpenPage("WebView");
            app.Back();

            OpenPage("OpenGLView");
            app.Back();

            OpenPage("Map");
            // Android: Map not displayed & SetLocation not working
            // iOS: Location not changing
            //app.Device.SetLocation(37.79762, -122.40181);
            //app.Screenshot("Xamarin HQ defined with 5 decmial points");
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
            app.Back();
        }

        [Test]
        public void ViewsThatInitiateCommands()
        {
            // Button page
            OpenPage("Button");
            app.Tap("Click Me!");
            app.Screenshot("Tapped Button");
            app.Back();

            // Image Button page
            OpenPage("ImageButton");
            //app.Tap("XamarinLogo");
            app.Tap("ImageButtonElement");
            app.Screenshot("Tapped Button");
            app.Back();

            // Search page
            OpenPage("SearchBar");
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

        [Test]
        public void ViewsForSettingValues()
        {
            string inc, dec;
            if (platform == Platform.iOS)
            {
                inc = "Increment";
                dec = "Decrement";
            }
            else
            {
                inc = "+";
                dec = "-";
            }

            // Slider (double)
            OpenPage("Slider (double)");
            app.SetSliderValue("SliderElement", 50.5);
            app.Screenshot("Slider at 50.5");
            app.Back();

            // Stepper (double)
            OpenPage("Stepper (double)");
            //Increment thrice
            app.Tap(inc);
            app.Tap(inc);
            app.Tap(inc);
            app.Screenshot("Stepper at 0.3");
            //Decrement twice
            app.Tap(dec);
            app.Tap(dec);
            app.Screenshot("Stepper at 0.1");
            app.Back();

            // Switch (bool)
            OpenPage("Switch (bool)");
            app.Tap("SwitchElement");
            app.Screenshot("Tapped switch using AutomationId");
            app.Back();

            // DatePicker
            OpenPage("DatePicker");
            app.Tap("DatePickerElement");
            app.Screenshot("Accessed Date Picker using AutomationId");
            // Set Date
            if (platform == Platform.iOS)
            {
                app.Tap("April");
                app.Tap("5");
                app.Tap("2020");
                app.Tap("Done");
            }
            else
            {
                // change year
                app.Tap("2019");
                app.Tap("2022");
                // change month
                // previous month
                app.Tap("prev");
                // next month
                app.Tap("next");
                app.Tap("next");
                // change day
                app.Tap("date_picker_day_picker"); // taps middle of whole month
                app.Tap("OK");
            }
            app.Screenshot("New Date set");
            app.Back();

            // TimePicker
            OpenPage("TimePicker");
            app.Tap("TimePickerElement");
            // Set Time
            if (platform == Platform.iOS)
            {
                app.Tap("8");
                app.Tap("01");
                app.Tap("PM");
                app.Tap("Done");
            } else
            {
                // switch to Text entry for time
                app.Tap("toggle_mode");
                // hour
                app.ClearText();
                app.EnterText("12");
                // minute
                app.ClearText("input_minute");
                app.EnterText("35");
                // AM/PM
                app.Tap("AM"); // opens spinner
                app.Tap("PM"); // changes to PM
                // finalize time
                app.Tap("OK");
            }
            app.Screenshot("new time set");
            app.Back();
        }


        [Test]
        public void ViewsForEditingText()
        {
            // Entry 
            OpenPage("Entry (single line)");
            // Enter Email address
            app.EnterText("Enter email address", "myEmail@example.com");
            app.Screenshot("Email entered");
            app.DismissKeyboard();
            app.Screenshot("keyboard dismissed");
            // Enter Password
            app.EnterText("Enter password", "password");
            app.Screenshot("password entered");
            app.DismissKeyboard();
            app.Screenshot("keyboard dismissed");
            // Enter phone number
            app.EnterText("Enter phone number", "8885550123");
            app.Screenshot("phone number entered");
            app.DismissKeyboard();
            app.Screenshot("keyboard dismissed");
            app.Back();
            if (platform == Platform.Android)
            {
                app.Back(); // needed because first .Back call just deselects field
            }
            // Editor
            OpenPage("Editor (multiple lines)");
            app.EnterText("EditorElement",
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                "Fusce hendrerit vulputate lacinia. " +
                "Nam consectetur turpis quis fermentum ultricies. " +
                "Vestibulum et turpis in orci condimentum laoreet in quis metus. " +
                "Praesent quis mattis odio."
                );
            app.Screenshot("entered text in editor");
            app.DismissKeyboard();
            app.Screenshot("keyboard dismissed");
            app.Back();
            if (platform == Platform.Android)
            {
                app.Back(); // needed because first .Back call just deselects field
            }
        }

        [Test]
        public void ViewsToIndicateActivity()
        {
            // Activity Indicator
            OpenPage("ActivityIndicator");
            app.Back();

            // Progress Bar
            OpenPage("ProgressBar");
            app.Back();
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
            } else app.Tap(x => x.Class("Switch"));
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
