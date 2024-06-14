using System;

namespace Aplikacja_gierki.Views
{
    public partial class EnterNumberOfParticipantsPage : ContentPage
    {
        public EnterNumberOfParticipantsPage()
        {
            InitializeComponent();
        }

        // Metoda obs³uguj¹ca klikniêcie przycisku "Dalej"
        private async void OnNextClicked(object sender, EventArgs e)
        {
            // Sprawdza, czy wpisana wartoœæ jest poprawn¹ liczb¹ uczestników (od 5 do 10)
            if (int.TryParse(NumberOfParticipantsEntry.Text, out int numberOfParticipants) && numberOfParticipants >= 5 && numberOfParticipants <= 10)
            {
                // Przenosi na stronê wprowadzania imion uczestników
                await Navigation.PushAsync(new EnterParticipantsNamesPage(numberOfParticipants));
            }
            else
            {
                // Wyœwietla komunikat o b³êdzie, jeœli wpisana wartoœæ jest niepoprawna
                await DisplayAlert("B³¹d", "Proszê wpisaæ liczbê uczestników od 5 do 10.", "OK");
            }
        }

        // Metoda obs³uguj¹ca fokus na polu tekstowym
        private void OnEntryFocused(object sender, FocusEventArgs e)
        {
            NumberOfParticipantsEntry.Focus();
        }
    }
}
