using Microsoft.Maui.Controls;
using Aplikacja_mobilnavfcv2.Views;

namespace Aplikacja_mobilnavfcv2
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
