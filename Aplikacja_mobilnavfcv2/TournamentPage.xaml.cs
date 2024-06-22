using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Aplikacja_gierki.Models;
using System.Threading.Tasks;

namespace Aplikacja_gierki.Views
{
    public partial class TournamentPage : ContentPage
    {
        private ObservableCollection<Race> AllRaces { get; set; } = new ObservableCollection<Race>();
        public ObservableCollection<Race> VisibleRaces { get; set; } = new ObservableCollection<Race>();

        // Konstruktor inicjalizuj¹cy stronê turniejow¹
        public TournamentPage(ObservableCollection<Participant> participants, int numberOfRaces)
        {
            InitializeComponent(); // Inicjalizacja komponentów
            NumberOfRacesLabel.Text = $"Liczba wyœcigów: {numberOfRaces}"; // Ustawienie liczby wyœcigów
            GenerateRaces(participants, numberOfRaces); // Generowanie wyœcigów
            LoadNextRaces(); // Wczytywanie pierwszych wyœcigów
            BindingContext = this; // Ustawienie kontekstu danych
        }

        // Metoda generuj¹ca wyœcigi na podstawie uczestników i liczby wyœcigów
        private void GenerateRaces(ObservableCollection<Participant> participants, int numberOfRaces)
        {
            var random = new Random();
            var participantList = participants.ToList();

            for (int i = 1; i <= numberOfRaces; i++)
            {
                var shuffledParticipants = participantList.OrderBy(x => random.Next()).Take(4).ToList();
                var raceParticipants = shuffledParticipants.Select(p => new RaceParticipant { Name = p.Name }).ToList();
                AllRaces.Add(new Race { Title = $"Wyœcig {i}", Participants = raceParticipants });
            }
        }

        // Metoda wczytuj¹ca kolejne wyœcigi do widocznej listy
        private void LoadNextRaces()
        {
            while (VisibleRaces.Count < 2 && AllRaces.Any())
            {
                VisibleRaces.Add(AllRaces.First());
                AllRaces.RemoveAt(0);
            }

            if (!AllRaces.Any() && !VisibleRaces.Any())
            {
                // Przeniesienie u¿ytkownika na stronê podsumowania po zakoñczeniu wszystkich wyœcigów
                Navigation.PushAsync(new SummaryPage());
            }
        }

        // Metoda obs³uguj¹ca klikniêcie przycisku "Akceptuj" dla wyœcigu
        private async void OnAcceptClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var race = button?.CommandParameter as Race;
            if (race != null)
            {
                await SaveRaceResultsAsync(race); // Zapis wyników wyœcigu
                VisibleRaces.Remove(race); // Usuniêcie wyœcigu z widocznej listy
                LoadNextRaces(); // Wczytanie kolejnych wyœcigów
            }
        }

        // Metoda zapisuj¹ca wyniki wyœcigu do bazy danych
        private async Task SaveRaceResultsAsync(Race race)
        {
            foreach (var participant in race.Participants)
            {
                var result = new RaceResult
                {
                    RaceTitle = race.Title,
                    ParticipantName = participant.Name,
                    Points = participant.Points
                };
                await App.BlurDatabase.SaveRaceResultAsync(result); // Zapis wyniku do bazy danych
            }
        }
    }

    // Klasa modelu wyœcigu
    public class Race
    {
        public string Title { get; set; } = string.Empty; // Tytu³ wyœcigu
        public List<RaceParticipant> Participants { get; set; } = new List<RaceParticipant>(); // Lista uczestników wyœcigu
    }

    // Klasa modelu uczestnika wyœcigu
    public class RaceParticipant
    {
        public string Name { get; set; } = string.Empty; // Nazwa uczestnika
        public int Points { get; set; } = 0; // Liczba punktów uczestnika
    }
}
