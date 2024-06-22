using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using Aplikacja_gierki.Models;

namespace Aplikacja_gierki.Views
{
    public partial class BlurHomePage : ContentPage
    {
        public BlurHomePage()
        {
            InitializeComponent();
        }

        private void OnFourPlayerClicked(object sender, EventArgs e)
        {
            // Tutaj mo¿esz dodaæ logikê dla 4-osobowego turnieju
        }

        private async void OnMoreThanFourPlayerClicked(object sender, EventArgs e)
        {
            // Przenosi na stronê wprowadzenia liczby uczestników
            await Navigation.PushAsync(new EnterNumberOfParticipantsPage());
        }

        private async void OnCurrentTournamentClicked(object sender, EventArgs e)
        {
            // Przenosi na stronê turniejow¹
            await Navigation.PushAsync(new TournamentPage(new ObservableCollection<Participant>(), 0)); // Przyk³adowa inicjalizacja
        }

        private async void OnResultsClicked(object sender, EventArgs e)
        {
            // Przenosi na stronê podsumowania wyników
            await Navigation.PushAsync(new SummaryPage());
        }

        private void OnExitClicked(object sender, EventArgs e)
        {
            // Przycisk wyjœcie
#if ANDROID
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
#else
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
#endif
        }
    }
}
