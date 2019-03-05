using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace FormsGallery.UITest
{
    public class HelperMethods
    {

        public IApp app;
        public Platform platform;

        public void OpenPage(string page, int pageType)
        {
            app.ScrollUp(); // makes sure state is reset
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

        public void SetDate(string month, int day, int year)
        {
            string dayString = day.ToString();
            string yearString = year.ToString();

            if (platform == Platform.iOS)
            {
                app.ScrollDownTo(x => x.Marked(month), x => x.Class("UIPickerTableView").Index(0));
                app.Tap(month);

                app.ScrollDownTo(x => x.Marked(dayString), x => x.Class("UIPickerTableView").Index(3), ScrollStrategy.Auto, 0.67, 500, true, new TimeSpan(0,2,0));
                app.Tap(dayString);

                if (year > 2019) // have to scroll up or down depending on if year is too far away from the current year AND if it's higher or lower
                {
                    app.ScrollDownTo(x => x.Marked(yearString), x => x.Class("UIPickerTableView").Index(6), ScrollStrategy.Auto, 0.67, 500, true, new TimeSpan(0, 2, 0));
                }
                else
                {
                    app.ScrollUpTo(x => x.Marked(yearString), x => x.Class("UIPickerTableView").Index(6), ScrollStrategy.Auto, 0.67, 500, true, new TimeSpan(0, 2, 0));
                }
                app.Tap(yearString);

            }
            else // Android
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
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

    }
}