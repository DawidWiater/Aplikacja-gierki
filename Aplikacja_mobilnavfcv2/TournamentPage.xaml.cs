using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Aplikacja_gierki.Models;
using Aplikacja_gierki.Data;
using System.Threading.Tasks;

namespace Aplikacja_gierki.Views
{
    public partial class TournamentPage : ContentPage
    {
        private ObservableCollection<Race> AllRaces { get; set; } = new ObservableCollection<Race>();
        public ObservableCollection<Race> VisibleRaces { get; set; } = new ObservableCollection<Race>();

        public TournamentPage(ObservableCollection<Participant> participants, int numberOfRaces)
        {
            InitializeComponent();
            NumberOfRacesLabel.Text = $"Liczba wyœcigów: {numberOfRaces}";
            GenerateRaces(participants, numberOfRaces);
            LoadNextRaces();
            BindingContext = this;
        }

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

        private void LoadNextRaces()
        {
            while (VisibleRaces.Count < 2 && AllRaces.Any())
            {
                VisibleRaces.Add(AllRaces.First());
                AllRaces.RemoveAt(0);
            }
        }

        private async void OnAcceptClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var race = button?.CommandParameter as Race;
            if (race != null)
            {
                await SaveRaceResultsAsync(race);
                VisibleRaces.Remove(race);
                LoadNextRaces();
            }
        }

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
                await App.BlurDatabase.SaveRaceResultAsync(result);
            }
        }
    }

    public class Race
    {
        public string Title { get; set; } = string.Empty;
        public List<RaceParticipant> Participants { get; set; } = new List<RaceParticipant>();
    }

    public class RaceParticipant
    {
        public string Name { get; set; } = string.Empty;
        public int Points { get; set; } = 0;
    }
}
