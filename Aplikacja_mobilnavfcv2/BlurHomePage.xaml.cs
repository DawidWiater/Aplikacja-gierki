
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

        // Metoda obs³uguj¹ca klikniêcie przycisku "4+ osobowy"
        private async void OnMoreThanFourPlayerClicked(object sender, EventArgs e)
        {
            // Przenosi na stronê wprowadzenia liczby uczestników
            await Navigation.PushAsync(new EnterNumberOfParticipantsPage());
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
