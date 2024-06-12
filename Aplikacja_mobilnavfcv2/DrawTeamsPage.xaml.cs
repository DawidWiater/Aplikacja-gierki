using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplikacja_gierki.Models;

namespace Aplikacja_gierki.Views
{
    public partial class DrawTeamsPage : ContentPage
    {
        private List<Entry> playerEntries;
        private int playerCount;

        public DrawTeamsPage(int playerCount)
        {
            InitializeComponent();
            this.playerCount = playerCount;
            playerEntries = new List<Entry>();

            for (int i = 0; i < playerCount; i++)
            {
                var entry = new Entry { Placeholder = $"Imi� Gracza {i + 1}" };
                playerEntries.Add(entry);
                PlayersStackLayout.Children.Add(entry);
            }
        }

        private async void OnDrawTeamsClicked(object sender, EventArgs e)
        {
            var teams = await App.Database.GetTeamsAsync();
            if (teams.Count < playerCount)
            {
                await DisplayAlert("B��d", "Liczba graczy nie mo�e by� wi�ksza ni� liczba zespo��w.", "OK");
                return;
            }

            var random = new Random();
            var shuffledTeams = teams.OrderBy(t => random.Next()).ToList();
            string results = "Wyniki losowania:\n";

            for (int i = 0; i < playerCount; i++)
            {
                var playerName = playerEntries[i].Text;
                if (string.IsNullOrWhiteSpace(playerName))
                {
                    await DisplayAlert("B��d", "Prosz� wpisa� imi� dla ka�dego gracza.", "OK");
                    return;
                }

                results += $"{playerName} zosta� przydzielony do zespo�u {shuffledTeams[i].Name}\n";
            }

            await DisplayAlert("Wynik losowania", results, "OK");

            await Navigation.PushAsync(new SecondPage());
        }
    }
}
