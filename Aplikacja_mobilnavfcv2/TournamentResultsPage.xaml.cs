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

        // Konstruktor inicjalizuj¹cy stronê z wynikami turnieju
        public TournamentResultsPage(ObservableCollection<Race> races)
        {
            InitializeComponent(); // Inicjalizacja komponentów
            CalculateResults(races); // Obliczanie wyników
            ResultsCollectionView.ItemsSource = Results; // Ustawienie Ÿród³a danych dla CollectionView
            BindingContext = this; // Ustawienie kontekstu danych
        }

        // Metoda obliczaj¹ca wyniki na podstawie wyœcigów
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

        // Metoda obs³uguj¹ca klikniêcie przycisku "Zapisz Turniej"
        private async void OnSaveTournamentClicked(object sender, EventArgs e)
        {
            foreach (var result in Results)
            {
                await App.BlurDatabase.SaveTournamentResultAsync(result); // Zapis wyników turnieju do bazy danych
            }

            await DisplayAlert("Sukces", "Wyniki turnieju zosta³y zapisane.", "OK"); // Wyœwietlenie komunikatu o sukcesie
        }
    }
}
