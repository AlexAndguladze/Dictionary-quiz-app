using System;
using System.Collections.Generic;
using MvvmHelpers;
using System.Text;
using MyDictionary.Models;
using System.Linq;

namespace MyDictionary.ViewModels
{
    public class GroupsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Word> Words { get; set; }
        public ObservableRangeCollection<Grouping<string, Word>> WordCollections { get; }
        public GroupsViewModel()
        {
            Title = "Collections";
            Words = new ObservableRangeCollection<Word>();
            WordCollections = new ObservableRangeCollection<Grouping<string, Word>>();

            Words.Add(new Word { TheWord = "Logistics", Phonetic= "ləˈdʒɪstɪks", Definition = "he detailed organization and implementation of a complex operation" });
            Words.Add(new Word { TheWord = "Firmware", Phonetic = "ˈfəːmwɛː", Definition = "permanent software programmed into a read-only memory" });
            Words.Add(new Word { TheWord = "პედანტი", Phonetic = "", Definition = "ა, რომელიც დიდ მნიშვნელობას ანიჭებს საქმის გარეგნულ მხარეს, წვრილმანებს, განუხრელად იცავს ფორმალურ წესებს და ამასვე მოითხოვს სხვებისაგან" });
            WordCollections.Add(new Grouping<string, Word>("English", Words.Take(2)));
            WordCollections.Add(new Grouping<string, Word>("ქართული", new[] { Words[2] }));
        }
    }
}
