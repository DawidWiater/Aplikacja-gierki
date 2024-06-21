using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Linq;
using Aplikacja_gierki.Models;
using System.Threading.Tasks;

namespace Aplikacja_gierki.Views
{
    public partial class TournamentResultsPage : ContentPage
    {
        public ObservableCollection<TournamentResult> Results { get; set; } = new ObservableCollection<TournamentResult>();

        // Konstruktor inicjalizuj�cy stron� z wynikami turnieju
        public TournamentResultsPage(ObservableCollection<Race> races)
        {
            InitializeComponent(); // Inicjalizacja komponent�w
            CalculateResults(races); // Obliczanie wynik�w
            ResultsCollectionView.ItemsSource = Results; // Ustawienie �r�d�a danych dla CollectionView
            BindingContext = this; // Ustawienie kontekstu danych
        }

        // Metoda obliczaj�ca wyniki na podstawie wy�cig�w
        private void CalculateResults(ObservableCollection<Race> races)
        {
            var participantResults = new Dictionary<string, TournamentResult>();

            foreach (var race in races)
            {
                foreach (var participant in race.Participants)
                {
                    if (!participantResults.ContainsKey(participant.Name))
                    {
                        participantResults[participant.Name] = new TournamentResult
                        {
                            Name = participant.Name,
                            TotalPoints = 0,
                            RacesParticipated = 0
                        };
                    }
                    participantResults[participant.Name].TotalPoints += participant.Points;
                    participantResults[participant.Name].RacesParticipated++;
                }
            }

            foreach (var result in participantResults.Values)
            {
                Results.Add(result);
            }
        }

        // Metoda obs�uguj�ca klikni�cie przycisku "Zapisz Turniej"
        private async void OnSaveTournamentClicked(object sender, EventArgs e)
        {
            foreach (var result in Results)
            {
                await App.BlurDatabase.SaveTournamentResultAsync(result); // Zapis wynik�w turnieju do bazy danych
            }

            await DisplayAlert("Sukces", "Wyniki turnieju zosta�y zapisane.", "OK"); // Wy�wietlenie komunikatu o sukcesie
        }
    }
}
