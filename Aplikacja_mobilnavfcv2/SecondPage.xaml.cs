using Microsoft.Maui.Controls;
using System;
#if ANDROID
using Android.OS;
#endif

namespace Aplikacja_gierki.Views
{
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        private async void OnAddTeamPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTeamPage());
        }

        private async void OnAddMultipleTeamsPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddMultipleTeamsPage());
        }

        private async void OnResetDatabaseClicked(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Resetuj Baz� Danych", "Czy na pewno chcesz usun�� wszystkie zespo�y?", "Tak", "Nie");
            if (confirm)
            {
                await App.Database.DeleteAllTeamsAsync();
                await DisplayAlert("Sukces", "Baza danych zosta�a zresetowana.", "OK");
            }
        }

        private async void OnShowTeamsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowTeamsPage());
        }

        private void OnExitClicked(object sender, EventArgs e)
        {
            // Specyficzne dla platformy Android zamkni�cie aplikacji
#if ANDROID
            Process.KillProcess(Process.MyPid());
#else
            // Alternatywne metody zamkni�cia aplikacji dla innych platform
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
#endif
        }

        private async void OnNextClicked(object sender, EventArgs e)
        {
            if (int.TryParse(PlayersEntry.Text, out int playerCount) && playerCount > 0)
            {
                var teams = await App.Database.GetTeamsAsync();
                if (playerCount > teams.Count)
                {
                    await DisplayAlert("B��d", "Liczba graczy nie mo�e by� wi�ksza ni� liczba zespo��w.", "OK");
                    return;
                }

                await Navigation.PushAsync(new DrawTeamsPage(playerCount));
            }
            else
            {
                await DisplayAlert("B��d", "Prosz� wpisa� poprawn� liczb� graczy.", "OK");
            }
        }
    }
}
