using System.Collections.ObjectModel;

namespace Aplikacja_gierki.Views
{
    public partial class EnterParticipantsNamesPage : ContentPage
    {
        // Kolekcja do przechowywania imion uczestnik�w
        public ObservableCollection<Participant> ParticipantsNames { get; set; }

        public EnterParticipantsNamesPage(int numberOfParticipants)
        {
            InitializeComponent();
            ParticipantsNames = new ObservableCollection<Participant>();
            // Dodaje puste pola dla ka�dego uczestnika
            for (int i = 0; i < numberOfParticipants; i++)
            {
                ParticipantsNames.Add(new Participant { Name = string.Empty });
            }
            BindingContext = this;
            ParticipantsNamesCollectionView.ItemsSource = ParticipantsNames;
        }

        // Metoda obs�uguj�ca klikni�cie przycisku "Dalej"
        private async void OnNextClicked(object sender, EventArgs e)
        {
            // Przenosi na stron� turniejow� z imionami uczestnik�w
            await Navigation.PushAsync(new TournamentPage(ParticipantsNames));
        }
    }

    // Klasa modelu do przechowywania imion uczestnik�w
    public class Participant
    {
        public string Name { get; set; } = string.Empty;
    }
}
