namespace Aplikacja_gierki.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnStartClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SecondPage());
        }
    }
}
