
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

        // Metoda obs�uguj�ca klikni�cie przycisku "4+ osobowy"
        private async void OnMoreThanFourPlayerClicked(object sender, EventArgs e)
        {
            // Przenosi na stron� wprowadzenia liczby uczestnik�w
            await Navigation.PushAsync(new EnterNumberOfParticipantsPage());
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
