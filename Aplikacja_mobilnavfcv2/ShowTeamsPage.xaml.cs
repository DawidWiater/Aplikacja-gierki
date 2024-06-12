using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using Aplikacja_gierki.Models;

namespace Aplikacja_gierki.Views
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
            var teams = await App.Database.GetTeamsAsync();
            if (teams != null)
            {
                TeamsListView.ItemsSource = teams;
            }
        }

        private async void OnDeleteTeamTapped(object sender, EventArgs e)
        {
            if (sender is Label label && label.BindingContext is Team team)
            {
                bool confirm = await DisplayAlert("Usuñ Zespó³", $"Czy na pewno chcesz usun¹æ zespó³ {team.Name}?", "Tak", "Nie");
                if (confirm)
                {
                    await App.Database.DeleteTeamAsync(team);
                    var teams = await App.Database.GetTeamsAsync();
                    if (teams != null)
                    {
                        TeamsListView.ItemsSource = teams;
                    }
                }
            }
        }
    }
}
