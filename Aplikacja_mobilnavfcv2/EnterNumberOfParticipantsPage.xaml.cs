using System;

namespace Aplikacja_gierki.Views
{
    public partial class EnterNumberOfParticipantsPage : ContentPage
    {
        public EnterNumberOfParticipantsPage()
        {
            InitializeComponent();
        }

        // Metoda obs�uguj�ca klikni�cie przycisku "Dalej"
        private async void OnNextClicked(object sender, EventArgs e)
        {
            // Sprawdza, czy wpisana warto�� jest poprawn� liczb� uczestnik�w (od 5 do 10)
            if (int.TryParse(NumberOfParticipantsEntry.Text, out int numberOfParticipants) && numberOfParticipants >= 5 && numberOfParticipants <= 10)
            {
                // Przenosi na stron� wprowadzania imion uczestnik�w
                await Navigation.PushAsync(new EnterParticipantsNamesPage(numberOfParticipants));
            }
            else
            {
                // Wy�wietla komunikat o b��dzie, je�li wpisana warto�� jest niepoprawna
                await DisplayAlert("B��d", "Prosz� wpisa� liczb� uczestnik�w od 5 do 10.", "OK");
            }
        }

        // Metoda obs�uguj�ca fokus na polu tekstowym
        private void OnEntryFocused(object sender, FocusEventArgs e)
        {
            NumberOfParticipantsEntry.Focus();
        }
    }
}
