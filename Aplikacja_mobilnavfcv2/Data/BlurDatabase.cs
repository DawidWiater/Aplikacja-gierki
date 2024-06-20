using Aplikacja_gierki.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplikacja_gierki.Data
{
    public class BlurDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public BlurDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<RaceResult>().Wait();
        }

        public Task<List<RaceResult>> GetRaceResultsAsync()
        {
            return _database.Table<RaceResult>().ToListAsync();
        }

        public Task<int> SaveRaceResultAsync(RaceResult result)
        {
            return _database.InsertAsync(result);
        }
    }
}
