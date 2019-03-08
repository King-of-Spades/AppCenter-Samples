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
                SetDatePicker(new DateTime(1985, 10, 26));
                app.Screenshot("New Date set: October 26th, 1985");
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
                SetTimePicker(1, 16, false);
                app.Screenshot("new time set");
                app.Back();
            }
        }
    }
}
