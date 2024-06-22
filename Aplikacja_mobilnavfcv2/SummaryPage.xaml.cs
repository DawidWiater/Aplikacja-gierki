using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using Aplikacja_gierki.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacja_gierki.Views
{
    public partial class SummaryPage : ContentPage
    {
        public ObservableCollection<TournamentResult> Results { get; set; } = new ObservableCollection<TournamentResult>();

        public SummaryPage()
        {
            InitializeComponent();
            LoadResultsAsync();
        }

        private async Task LoadResultsAsync()
        {
            var races = await App.BlurDatabase.GetRaceResultsAsync();
            CalculateResults(races);
            SummaryCollectionView.ItemsSource = Results;
            BindingContext = this;
        }

        // Metoda obliczaj¹ca wyniki na podstawie wyœcigów
        private void CalculateResults(List<RaceResult> raceResults)
        {
            var participantResults = new Dictionary<string, TournamentResult>();

            foreach (var result in raceResults)
            {
                if (!participantResults.ContainsKey(result.ParticipantName))
                {
                    participantResults[result.ParticipantName] = new TournamentResult
                    {
                        Name = result.ParticipantName,
                        TotalPoints = 0,
                        RacesParticipated = 0
                    };
                }
                participantResults[result.ParticipantName].TotalPoints += result.Points;
                participantResults[result.ParticipantName].RacesParticipated++;
            }

            foreach (var result in participantResults.Values)
            {
                Results.Add(result);
            }
        }

        private async void OnResetClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Reset", "Czy na pewno chcesz zresetowaæ wyniki?", "Tak", "Nie");
            if (answer)
            {
                await App.BlurDatabase.ResetDatabaseAsync();
                await Navigation.PushAsync(new BlurHomePage());
            }
        }
    }
}
