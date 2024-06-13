using Microsoft.Maui.Controls;
using System;

namespace Aplikacja_gierki.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void OnFifaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void OnGridClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BlurHomePage());
        }
    }
}
