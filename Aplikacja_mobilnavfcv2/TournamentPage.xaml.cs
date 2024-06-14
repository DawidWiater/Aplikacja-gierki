using System.Collections.ObjectModel;

namespace Aplikacja_gierki.Views
{
    public partial class TournamentPage : ContentPage
    {
        public TournamentPage(ObservableCollection<Participant> participants)
        {
            InitializeComponent();
            ParticipantsListView.ItemsSource = participants;
        }
    }
}
