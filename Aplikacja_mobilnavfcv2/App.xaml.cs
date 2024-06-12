using Microsoft.Maui.Controls;
using System;
using System.IO;

namespace Aplikacja_gierki
{
    public partial class App : Application
    {
        static TeamDatabase? database;

        public static TeamDatabase Database
        {
            get
            {
                if (database == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Teams.db3");
                    database = new TeamDatabase(dbPath);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage())
            {
                Title = "FC losowanie zespolow"  // Nowa nazwa aplikacji
            };
        }
    }
}
