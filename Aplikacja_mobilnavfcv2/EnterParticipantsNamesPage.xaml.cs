using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using Aplikacja_gierki.Models;

namespace Aplikacja_gierki.Views
{
    public partial class EnterParticipantsNamesPage : ContentPage
    {
        public ObservableCollection<Participant> ParticipantsNames { get; set; }

        public EnterParticipantsNamesPage(int numberOfParticipants)
        {
            InitializeComponent();
            ParticipantsNames = new ObservableCollection<Participant>();
            for (int i = 0; i < numberOfParticipants; i++)
            {
                ParticipantsNames.Add(new Participant { Name = string.Empty });
            }
            BindingContext = this;
            ParticipantsNamesCollectionView.ItemsSource = ParticipantsNames;
        }

        private async void OnNextClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EnterNumberOfRacesPage(ParticipantsNames));
        }
    }
}
