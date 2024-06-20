using Microsoft.Maui.Controls;
using System;
using System.IO;
using Aplikacja_gierki.Models;
using Aplikacja_gierki.Data;

namespace Aplikacja_gierki
{
    public partial class App : Application
    {
        static TeamDatabase? database;
        static BlurDatabase? blurDatabase;

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

        public static BlurDatabase BlurDatabase
        {
            get
            {
                if (blurDatabase == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BlurDatabase.db3");
                    blurDatabase = new BlurDatabase(dbPath);
                }
                return blurDatabase;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
