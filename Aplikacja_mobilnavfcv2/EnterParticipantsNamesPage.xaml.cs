using System.Collections.ObjectModel;

namespace Aplikacja_gierki.Views
{
    public partial class EnterParticipantsNamesPage : ContentPage
    {
        // Kolekcja do przechowywania imion uczestników
        public ObservableCollection<Participant> ParticipantsNames { get; set; }

        public EnterParticipantsNamesPage(int numberOfParticipants)
        {
            InitializeComponent();
            ParticipantsNames = new ObservableCollection<Participant>();
            // Dodaje puste pola dla ka¿dego uczestnika
            for (int i = 0; i < numberOfParticipants; i++)
            {
                ParticipantsNames.Add(new Participant { Name = string.Empty });
            }
            BindingContext = this;
            ParticipantsNamesCollectionView.ItemsSource = ParticipantsNames;
        }

        // Metoda obs³uguj¹ca klikniêcie przycisku "Dalej"
        private async void OnNextClicked(object sender, EventArgs e)
        {
            // Przenosi na stronê turniejow¹ z imionami uczestników
            await Navigation.PushAsync(new TournamentPage(ParticipantsNames));
        }
    }

    // Klasa modelu do przechowywania imion uczestników
    public class Participant
    {
        public string Name { get; set; } = string.Empty;
    }
}
