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
    public class ViewsForSettingValues : HelperMethods
    {
        public ViewsForSettingValues (Platform platform)
        {
            this.platform = platform;
        }

        [Test]
        public void Slider()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("Slider (double)", i);
                app.SetSliderValue("SliderElement", 50.5);
                app.Screenshot("Slider at 50.5");
                app.Back();
            }
           
        }

        [Test]
        public void Stepper()
        {
            string increment, decrement;
            if (platform == Platform.iOS)
            {
                increment = "Increment";
                decrement = "Decrement";
            }
            else
            {
                increment = "+";
                decrement = "-";
            }

            for (int i = 0; i <= 1; i++)
            {
                OpenPage("Stepper (double)", i);

                //Increment thrice
                app.Tap(increment);
                app.Tap(increment);
                app.Tap(increment);
                app.Screenshot("Stepper at 0.3");

                //Decrement twice
                app.Tap(decrement);
                app.Tap(decrement);
                app.Screenshot("Stepper at 0.1");
                app.Back();
            }

        }

        [Test]
        public void Switch ()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("Switch (bool)", i);
                app.Tap("SwitchElement");
                app.Screenshot("Tapped switch using AutomationId");
                app.Back();
            }
        }

        [Test]
        public void DatePicker ()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("DatePicker", i);
                app.Tap("DatePickerElement");
                app.Screenshot("Accessed Date Picker using AutomationId");
                // Better way to find & select value in Picker
                //app.ScrollDownTo(x => x.Marked("April"), x => x.Class("UIPickerTableView").Index(0));
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
            }
        }

        [Test]
        public void TimePicker()
        {
            for (int i = 0; i <= 1; i++)
            {
                // TimePicker
                OpenPage("TimePicker", i);
                app.Tap("TimePickerElement");
                // Set Time
                if (platform == Platform.iOS)
                {
                    app.Tap("5");
                    app.Tap("01");
                    app.Tap("PM");
                    app.Tap("Done");
                }
                else
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
        }
    }
}
