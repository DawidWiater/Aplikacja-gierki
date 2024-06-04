using Microsoft.Maui.Controls;
using System.Collections.Generic;
using Aplikacja_mobilnavfcv2.Models;

namespace Aplikacja_mobilnavfcv2.Views
{
    public partial class ShowTeamsPage : ContentPage
    {
        public ShowTeamsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            TeamsListView.ItemsSource = await App.Database.GetTeamsAsync();
        }
    }
}
