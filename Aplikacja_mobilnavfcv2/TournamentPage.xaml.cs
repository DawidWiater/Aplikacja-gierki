using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
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

        private Dictionary<string, int> ParticipantRaceCounts { get; set; } = new Dictionary<string, int>();
        private List<Participant> Participants { get; set; } = new List<Participant>();

        // Konstruktor inicjalizuj¹cy stronê turniejow¹
        public TournamentPage(ObservableCollection<Participant> participants, int numberOfRaces)
        {
            InitializeComponent(); // Inicjalizacja komponentów
            NumberOfRacesLabel.Text = $"Liczba wyœcigów: {numberOfRaces}"; // Ustawienie liczby wyœcigów
            Participants = participants.ToList();
            GenerateRaces(participants, numberOfRaces); // Generowanie wyœcigów
            LoadNextRaces(); // Wczytywanie pierwszych wyœcigów
            BindingContext = this; // Ustawienie kontekstu danych
        }

        // Metoda generuj¹ca wyœcigi na podstawie uczestników i liczby wyœcigów
        private void GenerateRaces(ObservableCollection<Participant> participants, int numberOfRaces)
        {
            var random = new Random();
            var participantList = participants.ToList();
            int participantCount = participantList.Count;

            // Initialize the dictionary to count the number of races each participant has joined
            foreach (var participant in participantList)
            {
                ParticipantRaceCounts[participant.Name] = 0;
            }

            for (int i = 1; i <= numberOfRaces; i++)
            {
                var raceParticipants = new List<RaceParticipant>();

                // Ensure each participant participates in at least all but one race
                var availableParticipants = participantList.Where(p => ParticipantRaceCounts[p.Name] < numberOfRaces - 1).ToList();
                var requiredParticipants = participantList.Where(p => ParticipantRaceCounts[p.Name] < (i - 1)).ToList();

                // If the available participants are fewer than 4, add the required participants to make it up
                if (availableParticipants.Count < 4)
                {
                    availableParticipants.AddRange(requiredParticipants);
                }

                // Shuffle and select participants for the race
                var selectedParticipants = availableParticipants.OrderBy(x => random.Next()).Take(4).ToList();

                // Add selected participants to the race and update their counts
                foreach (var participant in selectedParticipants)
                {
                    raceParticipants.Add(new RaceParticipant { Name = participant.Name });
                    ParticipantRaceCounts[participant.Name]++;
                }

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
