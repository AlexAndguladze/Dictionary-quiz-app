using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace MyDictionary.Models
{
    public class Word
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string TheWord { get; set; }
        public string Phonetic { get; set; }
        public string Definition { get; set; }
        public bool IsEnglish { get; set; }
    }
}
