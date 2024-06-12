using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using Aplikacja_gierki.Models;

namespace Aplikacja_gierki.Views
{
    public partial class AddMultipleTeamsPage : ContentPage
    {
        private List<Entry> teamEntries;

        public AddMultipleTeamsPage()
        {
            InitializeComponent();
            teamEntries = new List<Entry>();
        }

        private void OnNextClicked(object sender, EventArgs e)
        {
            if (int.TryParse(TeamCountEntry.Text, out int teamCount) && teamCount > 0)
            {
                TeamsStackLayout.Children.Clear();
                teamEntries.Clear();

                for (int i = 0; i < teamCount; i++)
                {
                    var entry = new Entry { Placeholder = $"Nazwa Zespo³u {i + 1}" };
                    teamEntries.Add(entry);
                    TeamsStackLayout.Children.Add(entry);
                }

                TeamsScrollView.IsVisible = true;
                SubmitTeamsButton.IsVisible = true;

                // Adjust ScrollView height based on the number of teams
                if (teamCount > 8)
                {
                    TeamsScrollView.HeightRequest = 400; // or any height you find suitable
                }
                else
                {
                    TeamsScrollView.HeightRequest = -1; // Auto size
                }
            }
            else
            {
                DisplayAlert("B³¹d", "Proszê wpisaæ poprawn¹ liczbê zespo³ów.", "OK");
            }
        }

        private async void OnSubmitTeamsClicked(object sender, EventArgs e)
        {
            foreach (var entry in teamEntries)
            {
                var teamName = entry.Text;
                if (!string.IsNullOrEmpty(teamName))
                {
                    await App.Database.SaveTeamAsync(new Team { Name = teamName });
                }
            }

            await Navigation.PushAsync(new SecondPage());
        }
    }
}
