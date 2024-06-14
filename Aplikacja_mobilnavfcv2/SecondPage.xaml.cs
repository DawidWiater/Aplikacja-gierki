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
            bool confirm = await DisplayAlert("Resetuj Bazê Danych", "Czy na pewno chcesz usun¹æ wszystkie zespo³y?", "Tak", "Nie");
            if (confirm)
            {
                await App.Database.DeleteAllTeamsAsync();
                await DisplayAlert("Sukces", "Baza danych zosta³a zresetowana.", "OK");
            }
        }

        private async void OnShowTeamsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowTeamsPage());
        }

        private void OnExitClicked(object sender, EventArgs e)
        {
#if ANDROID
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
#else
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
                    await DisplayAlert("B³¹d", "Liczba graczy nie mo¿e byæ wiêksza ni¿ liczba zespo³ów.", "OK");
                    return;
                }

                await Navigation.PushAsync(new DrawTeamsPage(playerCount));
            }
            else
            {
                await DisplayAlert("B³¹d", "Proszê wpisaæ poprawn¹ liczbê graczy.", "OK");
            }
        }
    }
}
