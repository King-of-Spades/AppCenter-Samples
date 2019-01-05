using System;
using Xamarin.Forms;

namespace FormsGallery.CodeExamples
{
    class EditorDemoPage : ContentPage
    {
        public EditorDemoPage()
        {
            Label header = new Label
            {
                Text = "Editor",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            Editor editor = new Editor
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(10),
                AutomationId = "EditorElement"
            };

            // Build the page.
            Title = "Editor Demo";
            Content = new StackLayout
            {
                Children = 
                {
                    header,
                    editor
                }
            };
        }
    }
}
