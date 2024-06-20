using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using Aplikacja_gierki.Models;

namespace Aplikacja_gierki.Views
{
    public partial class EnterNumberOfRacesPage : ContentPage
    {
        private ObservableCollection<Participant> participants;

        public EnterNumberOfRacesPage(ObservableCollection<Participant> participants)
        {
            InitializeComponent();
            this.participants = participants;
        }

        private async void OnNextClicked(object sender, EventArgs e)
        {
            if (int.TryParse(NumberOfRacesEntry.Text, out int numberOfRaces) && numberOfRaces > 0)
            {
                // Przenosi na stronê turniejow¹ z imionami uczestników i liczb¹ wyœcigów
                await Navigation.PushAsync(new TournamentPage(participants, numberOfRaces));
            }
            else
            {
                await DisplayAlert("B³¹d", "Proszê wpisaæ poprawn¹ liczbê wyœcigów.", "OK");
            }
        }
    }
}
