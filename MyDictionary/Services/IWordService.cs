using MyDictionary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDictionary.Services
{
    public interface IWordService
    {
        Task AddWord(string word, string phonetic, string definition, bool isEnglish);
        Task<List<Word>> GetEnglishWord();
        Task<List<Word>> GetEnglishWords();
        Task<List<Word>> GetGeorgianWord();
        Task<List<Word>> GetGeorgianWords();
        Task<List<Word>> GetRandomWord();
        Task<IEnumerable<Word>> GetWord();
        Task RemoveWord(int id);
    }
}