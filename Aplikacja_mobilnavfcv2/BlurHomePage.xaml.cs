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
            // Tutaj mo�esz doda� logik� dla 4-osobowego turnieju
        }

        private async void OnMoreThanFourPlayerClicked(object sender, EventArgs e)
        {
            // Przenosi na stron� wprowadzenia liczby uczestnik�w
            await Navigation.PushAsync(new EnterNumberOfParticipantsPage());
        }

        private async void OnCurrentTournamentClicked(object sender, EventArgs e)
        {
            // Przenosi na stron� turniejow�
            await Navigation.PushAsync(new TournamentPage(new ObservableCollection<Participant>(), 0)); // Przyk�adowa inicjalizacja
        }

        private async void OnResultsClicked(object sender, EventArgs e)
        {
            // Przenosi na stron� podsumowania wynik�w
            await Navigation.PushAsync(new SummaryPage());
        }

        private void OnExitClicked(object sender, EventArgs e)
        {
            // Przycisk wyj�cie
#if ANDROID
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
#else
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
#endif
        }
    }
}
