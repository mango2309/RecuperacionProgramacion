using RecuperacionProgramacion.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecuperacionProgramacion.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Character>().Wait();
        }

        public Task<List<Character>> GetCharactersAsync()
        {
            return _database.Table<Character>().ToListAsync();
        }

        public Task<int> SaveCharacterAsync(Character character)
        {
            return _database.InsertAsync(character);
        }

        public Task<int> DeleteCharacterAsync(Character character)
        {
            return _database.DeleteAsync(character);
        }
    }
}
