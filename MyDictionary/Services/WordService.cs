using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using MyDictionary.Models;

namespace MyDictionary.Services
{
    public class WordService : IWordService
    {
        SQLiteAsyncConnection db;
        async Task Init()
        {
            if (db != null)
                return;
            // Get an absolute path to the database file
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyData.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Word>();
        }
        public async Task AddWord(string word, string phonetic, string definition, bool isEnglish)
        {
            await Init();
            var newWord = new Word
            {
                TheWord = word,
                Phonetic = phonetic,
                Definition = definition,
                IsEnglish = isEnglish
            };
            var id = await db.InsertAsync(newWord);
        }

        public async Task RemoveWord(int id)
        {
            await Init();
            await db.DeleteAsync<Word>(id);
        }
        public async Task<IEnumerable<Word>> GetWord()
        {
            await Init();
            var words = await db.Table<Word>().ToListAsync();
            return words;
        }
        public async Task<List<Word>> GetGeorgianWords()
        {
            await Init();

            var list = db.QueryAsync<Word>("SELECT * FROM Word WHERE IsEnglish = false");
            return await list;
        }
        public async Task<List<Word>> GetEnglishWords()
        {
            await Init();

            var list = db.QueryAsync<Word>("SELECT * FROM Word WHERE IsEnglish = true");
            return await list;
        }
        public async Task<List<Word>> GetEnglishWord()
        {
            await Init();

            var words = await db.QueryAsync<Word>("SELECT*FROM word WHERE isEnglish = true ORDER BY RANDOM() LIMIT 3");
            return words;
        }
        public async Task<List<Word>> GetGeorgianWord()
        {
            await Init();

            var words = await db.QueryAsync<Word>("SELECT*FROM word WHERE isEnglish = false ORDER BY RANDOM() LIMIT 3");
            return words;
        }
        public async Task<List<Word>> GetRandomWord()
        {
            await Init();

            var words = await db.QueryAsync<Word>("SELECT*FROM word ORDER BY RANDOM() LIMIT 3");
            return words;
        }
    }
}
