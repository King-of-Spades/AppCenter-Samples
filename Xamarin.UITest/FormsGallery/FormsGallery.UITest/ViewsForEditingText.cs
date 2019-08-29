using System;
using System.IO;
using System.Linq;
using System.Threading;
using EmbeddedResources;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace FormsGallery.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class ViewsForEditingText : HelperMethods
    {
        public ViewsForEditingText(Platform platform)
        {
            this.platform = platform;
        }

        [Test]
        public void Entry()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("Entry (single line)", i);
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
            }
        }

        [Test]
        public void Editor()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("Editor (multiple lines)", i);
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
        }

        [Test]
        public void EditorEmbeddedFile()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("Editor (multiple lines)", i);

                // Read the text file line by line
                StreamReader stream = new StreamReader(ResourceLoader.GetEmbeddedResourceStream("embeddedDataFile.txt"));
                String line1 = stream.ReadLine();
                String line2 = stream.ReadLine();
                String line3 = stream.ReadLine();

                app.EnterText("EditorElement", line1 + line2 + line3);
                app.Screenshot("entered text in editor");
                app.DismissKeyboard();
                app.Screenshot("keyboard dismissed");
                app.Back();
                if (platform == Platform.Android)
                {
                    app.Back(); // needed because first .Back call just deselects field
                }
            }
        }


        [Test]
        public void EditorIncludedFile()
        {
            for (int i = 0; i <= 1; i++)
            {
                OpenPage("Editor (multiple lines)", i);

                // Read the text file line by line
                StreamReader stream = new StreamReader("./includedDataFile.txt");
                String line1 = stream.ReadLine();
                String line2 = stream.ReadLine();
                String line3 = stream.ReadLine();

                app.EnterText("EditorElement", line1 + line2 + line3);
                app.Screenshot("entered text in editor");
                app.DismissKeyboard();
                app.Screenshot("keyboard dismissed");
                app.Back();
                if (platform == Platform.Android)
                {
                    app.Back(); // needed because first .Back call just deselects field
                }
            }
        }
    }
}
