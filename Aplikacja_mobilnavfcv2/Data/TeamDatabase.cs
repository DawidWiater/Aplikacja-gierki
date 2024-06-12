using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplikacja_gierki.Models;

namespace Aplikacja_gierki
{
    public class TeamDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public TeamDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Team>().Wait();
        }

        public Task<List<Team>> GetTeamsAsync()
        {
            if (_database != null)
            {
                return _database.Table<Team>().ToListAsync();
            }
            return Task.FromResult(new List<Team>());
        }

        public Task<int> SaveTeamAsync(Team team)
        {
            if (_database != null && team != null)
            {
                return _database.InsertAsync(team);
            }
            return Task.FromResult(0);
        }

        public Task<int> DeleteTeamAsync(Team team)
        {
            if (_database != null && team != null)
            {
                return _database.DeleteAsync(team);
            }
            return Task.FromResult(0);
        }

        // Nowa metoda do usuwania wszystkich zespołów
        public Task<int> DeleteAllTeamsAsync()
        {
            if (_database != null)
            {
                return _database.DeleteAllAsync<Team>();
            }
            return Task.FromResult(0);
        }
    }
}
