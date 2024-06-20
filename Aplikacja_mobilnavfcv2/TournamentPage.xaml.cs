using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Aplikacja_gierki.Models;

namespace Aplikacja_gierki.Views
{
    public partial class TournamentPage : ContentPage
    {
        public ObservableCollection<Race> Races { get; set; } = new ObservableCollection<Race>();

        public TournamentPage(ObservableCollection<Participant> participants, int numberOfRaces)
        {
            InitializeComponent();
            NumberOfRacesLabel.Text = $"Liczba wy�cig�w: {numberOfRaces}";
            GenerateRaces(participants, numberOfRaces);
            RacesCollectionView.ItemsSource = Races;
        }

        private void GenerateRaces(ObservableCollection<Participant> participants, int numberOfRaces)
        {
            var random = new Random();
            var participantList = participants.ToList();

            for (int i = 1; i <= numberOfRaces; i++)
            {
                var shuffledParticipants = participantList.OrderBy(x => random.Next()).Take(4).ToList();
                var raceParticipants = shuffledParticipants.Select(p => new RaceParticipant { Name = p.Name }).ToList();
                Races.Add(new Race { Title = $"Wy�cig {i}", Participants = raceParticipants });
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
