using Microsoft.Maui.Controls;
using System;
#if ANDROID
using Android.OS;
#endif

namespace Aplikacja_mobilnavfcv2
{
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        private void OnNextClicked(object sender, EventArgs e)
        {
            // Tymczasowo przycisk nie bêdzie wykonywa³ ¿adnej akcji
        }

        private void OnAddTeamPageClicked(object sender, EventArgs e)
        {
            // Tymczasowo przycisk nie bêdzie wykonywa³ ¿adnej akcji
        }

        private void OnAddMultipleTeamsPageClicked(object sender, EventArgs e)
        {
            // Tymczasowo przycisk nie bêdzie wykonywa³ ¿adnej akcji
        }

        private void OnResetDatabaseClicked(object sender, EventArgs e)
        {
            // Tymczasowo przycisk nie bêdzie wykonywa³ ¿adnej akcji
        }

        private void OnShowTeamsClicked(object sender, EventArgs e)
        {
            // Tymczasowo przycisk nie bêdzie wykonywa³ ¿adnej akcji
        }

        private void OnExitClicked(object sender, EventArgs e)
        {
            // Specyficzne dla platformy Android zamkniêcie aplikacji
#if ANDROID
            Process.KillProcess(Process.MyPid());
#else
            // Alternatywne metody zamkniêcia aplikacji dla innych platform
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
#endif
        }
    }
}
