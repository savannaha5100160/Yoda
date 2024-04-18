using MauiAppShellMvvm.Configuration;
using MauiAppShellMvvm.Models;
using MauiAppShellMvvm.Services;
using SQLite;
using System.Runtime;

namespace BankingLocalMaui.Services
{
    public class ExampleLocalDatabase : IExampleCounterStore
    {
        private SQLiteConnection _dbConnection;
        private ISettings _settings;
  
        private string GetDatabasePath()
        {
           string filename = _settings.SqliteDbName;
           string pathToDb = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
           return Path.Combine(pathToDb, filename);  
        }

        public ExampleLocalDatabase(ISettings settings)
        {
            _settings = settings;

            _dbConnection = new SQLiteConnection(GetDatabasePath());

            _dbConnection.CreateTable<ExampleTable>();

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            if (_dbConnection.Table<ExampleTable>().Count() == 0) {

                var firstEntry = new ExampleTable();
                firstEntry.Name = "Example Count";
                firstEntry.Counter = 0;
                _dbConnection.Insert(firstEntry);
            }

        }

        public int GetLatestCounter()
        {
            var entry = _dbConnection.Table<ExampleTable>().FirstOrDefault();

            if (entry != null)
                return entry.Counter;

            return 0;
        }

        public void UpdateCounter(int counterValue)
        {
            var entry = _dbConnection.Table<ExampleTable>().FirstOrDefault();

            if (entry != null)
            {
                entry.Counter = counterValue;
                _dbConnection.InsertOrReplace(entry);
            }
        }
    }
}
