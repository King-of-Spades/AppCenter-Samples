using System;
using NUnit.Framework;
using Xamarin.UITest;
using System.Globalization;

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


        public void SetDatePicker(DateTime date)
        {
            string month = DateTimeFormatInfo.CurrentInfo.GetMonthName(date.Month);
            string day = date.Day.ToString();
            string year = date.Year.ToString();

            if (platform == Platform.iOS)
            {
                app.ScrollDownTo(x => x.Marked(month), x => x.Class("UIPickerTableView").Index(0));
                app.Tap(month);

                app.ScrollDownTo(x => x.Marked(day), x => x.Class("UIPickerTableView").Index(3), ScrollStrategy.Auto, 0.67, 500, true, new TimeSpan(0, 2, 0));
                app.Tap(day);

                int checkYear = DateTime.Compare(DateTime.Now, date);

                if (checkYear < 0)
                {
                    app.ScrollDownTo(x => x.Marked(year), x => x.Class("UIPickerTableView").Index(6), ScrollStrategy.Auto, 0.67, 500, true, new TimeSpan(0, 2, 0));
                }
                else
                {
                    app.ScrollUpTo(x => x.Marked(year), x => x.Class("UIPickerTableView").Index(6), ScrollStrategy.Auto, 0.67, 500, true, new TimeSpan(0, 2, 0));
                }
            } else // android
            {
                // change year
                //        app.Tap("2019");
                //        app.Tap("2022");
                //        // change month
                //        // previous month
                //        app.Tap("prev");
                //        // next month
                //        app.Tap("next");
                //        app.Tap("next");
                //        // change day
                //        app.Tap("date_picker_day_picker"); // taps middle of whole month
                //        app.Tap("OK");
            }
        }

        public void SetTimePicker(int hour, int minute, bool am)
        {
            string hourString = hour.ToString();
            string minuteString = minute.ToString();

            if (platform == Platform.iOS)
            {
                app.ScrollDownTo(x => x.Marked(hourString), x => x.Class("UIPickerTableView").Index(0));
                app.Tap(hourString);

                app.ScrollDownTo(x => x.Marked(minuteString), x => x.Class("UIPickerTableView").Index(3), ScrollStrategy.Auto, 0.67, 500, true, new TimeSpan(0, 2, 0));
                app.Tap(minuteString);

                if (am)
                {
                    app.Tap("AM");
                }
                else app.Tap("PM");

            } else // Android
            {
                // switch to Text entry for time
                //app.Tap("toggle_mode");
                //// hour
                //app.ClearText();
                //app.EnterText("12");
                //// minute
                //app.ClearText("input_minute");
                //app.EnterText("35");
                //// AM/PM
                //app.Tap("AM"); // opens spinner
                //app.Tap("PM"); // changes to PM
                //               // finalize time
                //app.Tap("OK");
            }
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

    }
}