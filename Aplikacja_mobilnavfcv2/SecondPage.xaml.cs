using Microsoft.Maui.Controls;
using System;
#if ANDROID
using Android.OS;
#endif

namespace Aplikacja_mobilnavfcv2.Views
{
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        private void OnNextClicked(object sender, EventArgs e)
        {
            // Tymczasowo przycisk nie b�dzie wykonywa� �adnej akcji
        }

        private async void OnAddTeamPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTeamPage());
        }

        private async void OnAddMultipleTeamsPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddMultipleTeamsPage());
        }

        private void OnResetDatabaseClicked(object sender, EventArgs e)
        {
            // Tymczasowo przycisk nie b�dzie wykonywa� �adnej akcji
        }

        private void OnShowTeamsClicked(object sender, EventArgs e)
        {
            // Tymczasowo przycisk nie b�dzie wykonywa� �adnej akcji
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
    }
}
