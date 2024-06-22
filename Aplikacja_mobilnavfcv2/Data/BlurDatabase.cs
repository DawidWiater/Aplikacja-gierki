using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aplikacja_gierki.Models;

namespace Aplikacja_gierki.Data
{
    public class BlurDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public BlurDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<RaceResult>().Wait();
            _database.CreateTableAsync<TournamentResult>().Wait();
        }

        public Task<List<RaceResult>> GetRaceResultsAsync()
        {
            return _database.Table<RaceResult>().ToListAsync();
        }

        public Task<int> SaveRaceResultAsync(RaceResult result)
        {
            return _database.InsertAsync(result);
        }

        public Task<int> SaveTournamentResultAsync(TournamentResult result)
        {
            return _database.InsertAsync(result);
        }

        public async Task ResetDatabaseAsync()
        {
            await _database.DropTableAsync<RaceResult>();
            await _database.DropTableAsync<TournamentResult>();
            await _database.CreateTableAsync<RaceResult>();
            await _database.CreateTableAsync<TournamentResult>();
        }
    }
}
