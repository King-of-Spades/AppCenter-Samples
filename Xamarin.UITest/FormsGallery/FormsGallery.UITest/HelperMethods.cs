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
            // needed to tap & thus select the items
            string month = DateTimeFormatInfo.CurrentInfo.GetMonthName(date.Month);
            string day = date.Day.ToString();
            string year = date.Year.ToString();

            if (platform == Platform.iOS)
            {
                //Invoke the native method selectRow() 
                app.Query(x => x.Class("UIPickerView").Invoke("selectRow", date.Month, "inComponent", 0, "animated", true)); // brings month in scope
                app.Tap(month); // actually selects month

                app.Query(x => x.Class("UIPickerView").Invoke("selectRow", date.Day, "inComponent", 1, "animated", true));
                app.Tap(day);

                app.Query(x => x.Class("UIPickerView").Invoke("selectRow", date.Year, "inComponent", 2, "animated", true));
                app.Tap(year);
            } else // Android
            {
                app.Query(x => x.Class("DatePicker").Invoke("updateDate", date.Year, date.Month, date.Day));
                app.Tap("OK");
            }
        }

        public void SetTimePicker(int hour, int minute, bool am)
        {
            string hourString = hour.ToString();
            string minuteString = minute.ToString();
            DateTime date = DateTime.Now;

            DateTime time = new DateTime(date.Year, date.Month, date.Day, hour, minute, 0);
            int ampm;

            if (am)
            {
                ampm = 0;
            }
            else ampm = 1;

            if (platform == Platform.iOS)
            {
                app.Query(x => x.Class("UIPickerView").Invoke("selectRow", time.Hour, "inComponent", 0, "animated", true)); //if time.Hour == 0, than hour is '1'. if time.Hour == 11, than hour is '12'
                app.Query(x => x.Class("UIPickerView").Invoke("selectRow", time.Minute, "inComponent", 1, "animated", true)); //if time.Minute == 0, than minutes is '1'. if time.Minute == 59, than minutes is '59'
                app.Query(x => x.Class("UIPickerView").Invoke("selectRow", ampm, "inComponent", 2, "animated", true)); //0 == AM and 1 == PM

            } else // Android
            {
                // switch to Text entry for time
                app.Tap("toggle_mode");
                // hour
                app.ClearText();
                app.EnterText(hourString);
                // minute
                app.ClearText("input_minute");
                app.EnterText(minuteString);
                // AM/PM
                if (!am)
                {
                    app.Tap("AM"); // opens spinner
                    app.Tap("PM"); // changes to PM 
                }
                app.Tap("OK"); // finalize time
            }
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

    }
}