using System;

using Xamarin.Forms;

namespace UITestDemo
{
    public partial class AboutPage : ContentPage
    {
        ItemsViewModel viewModel;
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemsViewModel();
            logo1.Rotation = 90;
        }

        async void logo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
