using Microsoft.Maui.Controls;
using Aplikacja_gierki.Models;
using System;

namespace Aplikacja_gierki.Views
{
    public partial class AddTeamPage : ContentPage
    {
        public AddTeamPage()
        {
            InitializeComponent();
        }

        private async void OnAddTeamClicked(object sender, EventArgs e)
        {
            var teamName = TeamNameEntry.Text;

            if (!string.IsNullOrEmpty(teamName))
            {
                await App.Database.SaveTeamAsync(new Team { Name = teamName });

                StatusLabel.Text = "Zespół został dodany.";
                StatusLabel.IsVisible = true;

                TeamNameEntry.Text = string.Empty;
            }
            else
            {
                StatusLabel.Text = "Proszę wpisać nazwę zespołu.";
                StatusLabel.TextColor = Colors.Red;
                StatusLabel.IsVisible = true;
            }
        }
    }
}
