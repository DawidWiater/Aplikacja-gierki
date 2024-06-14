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

        private void OnMoreThanFourPlayerClicked(object sender, EventArgs e)
        {
            // Tutaj mo¿esz dodaæ logikê dla 4+ osobowego turnieju
        }

        private void OnExitClicked(object sender, EventArgs e)
        {
#if ANDROID
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
#else
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
#endif
        }
    }
}
