using MvvmHelpers;
using MvvmHelpers.Commands;
using MyDictionary.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyDictionary.ViewModels
{
    internal class AddEnglishWordViewModel : BaseViewModel
    {
        string word, phonetic, definition;
        public string Word { get => word; set => SetProperty(ref word, value); }
        public string Phonetic { get => phonetic; set => SetProperty(ref phonetic, value); }
        public string Definition { get => definition; set => SetProperty(ref definition, value); }

        public AsyncCommand saveCommand { get; }
        IWordService wordService;
        public AddEnglishWordViewModel()
        {
            Title = "Add Word";
            saveCommand = new AsyncCommand(Save);
            wordService = DependencyService.Get<IWordService>();
        }

        private async Task Save()
        {
            if (String.IsNullOrEmpty(Word) || String.IsNullOrEmpty(Definition)){
                return;
            }
            await wordService.AddWord(Word, Phonetic, Definition, true);
            await Shell.Current.GoToAsync("..");
            MessagingCenter.Send<AddEnglishWordViewModel>(this, "RefreshEng");
            Console.WriteLine("pozpoz");
        }
    }
}
