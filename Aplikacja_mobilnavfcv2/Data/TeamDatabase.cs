using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplikacja_mobilnavfcv2.Models;

namespace Aplikacja_mobilnavfcv2
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
            return _database.Table<Team>().ToListAsync();
        }

        public Task<int> SaveTeamAsync(Team team)
        {
            return _database.InsertAsync(team);
        }

        public Task<int> DeleteTeamAsync(Team team)
        {
            return _database.DeleteAsync(team);
        }

        // Nowa metoda do usuwania wszystkich zespołów
        public Task<int> DeleteAllTeamsAsync()
        {
            return _database.DeleteAllAsync<Team>();
        }
    }
}
