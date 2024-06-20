using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Aplikacja_gierki.Models;

namespace Aplikacja_gierki.Views
{
    public partial class TournamentPage : ContentPage
    {
        public ObservableCollection<Race> Races { get; set; }

        public TournamentPage(ObservableCollection<Participant> participants, int numberOfRaces)
        {
            InitializeComponent();
            NumberOfRacesLabel.Text = $"Liczba wyœcigów: {numberOfRaces}";
            Races = new ObservableCollection<Race>();
            GenerateRaces(participants, numberOfRaces);
            RacesCollectionView.ItemsSource = Races;
        }

        private void GenerateRaces(ObservableCollection<Participant> participants, int numberOfRaces)
        {
            var random = new Random();
            var participantList = participants.ToList();

            for (int i = 1; i <= numberOfRaces; i++)
            {
                var shuffledParticipants = participantList.OrderBy(x => random.Next()).ToList();
                var raceParticipants = string.Join(", ", shuffledParticipants.Take(4).Select(p => p.Name));
                Races.Add(new Race { Title = $"Wyœcig {i}", Participants = raceParticipants });
            }
        }
    }

    public class Race
    {
        public string Title { get; set; }
        public string Participants { get; set; }
    }
}
