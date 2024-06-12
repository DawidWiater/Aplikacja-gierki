using Microsoft.Maui.Controls;
using Aplikacja_gierki.Views;

namespace Aplikacja_gierki
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
