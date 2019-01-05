using System;
using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    class TimePickerDemoPage : ContentPage
    {
        public TimePickerDemoPage()
        {
            Label header = new Label
            {
                Text = "TimePicker",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            TimePicker timePicker = new TimePicker
            {
                Format = "T",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(10, 0),
                AutomationId = "TimePickerElement",
#if DEBUG
                Time = new TimeSpan(8, 0, 0) // force time for consistent testing
#endif
            };

            // Build the page.
            Title = "TimePicker Demo";
            Content = new StackLayout
            {
                Children = 
                {
                    header,
                    timePicker
                }
            };
        }
    }
}
