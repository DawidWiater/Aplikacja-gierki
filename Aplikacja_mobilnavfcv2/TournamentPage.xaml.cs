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

        // Konstruktor inicjalizuj�cy stron� turniejow�
        public TournamentPage(ObservableCollection<Participant> participants, int numberOfRaces)
        {
            InitializeComponent(); // Inicjalizacja komponent�w
            NumberOfRacesLabel.Text = $"Liczba wy�cig�w: {numberOfRaces}"; // Ustawienie liczby wy�cig�w
            Participants = participants.ToList();
            GenerateRaces(participants, numberOfRaces); // Generowanie wy�cig�w
            LoadNextRaces(); // Wczytywanie pierwszych wy�cig�w
            BindingContext = this; // Ustawienie kontekstu danych
        }

        // Metoda generuj�ca wy�cigi na podstawie uczestnik�w i liczby wy�cig�w
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

                AllRaces.Add(new Race { Title = $"Wy�cig {i}", Participants = raceParticipants });
            }
        }

        // Metoda wczytuj�ca kolejne wy�cigi do widocznej listy
        private void LoadNextRaces()
        {
            while (VisibleRaces.Count < 2 && AllRaces.Any())
            {
                VisibleRaces.Add(AllRaces.First());
                AllRaces.RemoveAt(0);
            }

            if (!AllRaces.Any() && !VisibleRaces.Any())
            {
                // Przeniesienie u�ytkownika na stron� podsumowania po zako�czeniu wszystkich wy�cig�w
                Navigation.PushAsync(new SummaryPage());
            }
        }

        // Metoda obs�uguj�ca klikni�cie przycisku "Akceptuj" dla wy�cigu
        private async void OnAcceptClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var race = button?.CommandParameter as Race;
            if (race != null)
            {
                await SaveRaceResultsAsync(race); // Zapis wynik�w wy�cigu
                VisibleRaces.Remove(race); // Usuni�cie wy�cigu z widocznej listy
                LoadNextRaces(); // Wczytanie kolejnych wy�cig�w
            }
        }

        // Metoda zapisuj�ca wyniki wy�cigu do bazy danych
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

    // Klasa modelu wy�cigu
    public class Race
    {
        public string Title { get; set; } = string.Empty; // Tytu� wy�cigu
        public List<RaceParticipant> Participants { get; set; } = new List<RaceParticipant>(); // Lista uczestnik�w wy�cigu
    }

    // Klasa modelu uczestnika wy�cigu
    public class RaceParticipant
    {
        public string Name { get; set; } = string.Empty; // Nazwa uczestnika
        public int Points { get; set; } = 0; // Liczba punkt�w uczestnika
    }
}
