using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MyDictionary.Models;
using System.Threading.Tasks;
using Xamarin.Forms;
using MyDictionary.Services;
using MyDictionary.Views;

namespace MyDictionary.ViewModels
{
    public class EnglishWordsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Word> WordCol { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<object> SelectedCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<Word> RemoveCommand { get; }
        IWordService wordService;
        public EnglishWordsViewModel()
        {
            WordCol = new ObservableRangeCollection<Word>();

            RefreshCommand = new AsyncCommand(Refresh);
            SelectedCommand = new AsyncCommand<object>(Selected);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<Word>(Remove);
            wordService = DependencyService.Get<IWordService>();
        }

       private Word selectedWord;
        public Word SelectedWord
        {
            get => selectedWord;
            set => SetProperty(ref selectedWord, value);

        }
        async Task Selected(object args)
        {
            var word = args as Word;
            if (word == null)
                return;

            string title;
            if (word.Phonetic != string.Empty)
            {
                title = string.Format("{0} \u2022 {1}", word.TheWord, word.Phonetic);
            }
            else
            {
                title = word.TheWord;
            }
            SelectedWord = null;
            await Application.Current.MainPage.DisplayAlert(title, word.Definition, "OK");
        }
        async Task Add()
        {/*
            var word = await App.Current.MainPage.DisplayPromptAsync("Word", "New Word");
            var phonetic = await App.Current.MainPage.DisplayPromptAsync("Phonetic", "New Word");
            var definiton = await App.Current.MainPage.DisplayPromptAsync("Definition", "Definition of word");
            await WordService.AddWord(word, phonetic, definiton, true);
            await Refresh();*/
            var route = $"{nameof(AddEnglishWordPage)}";
            await Shell.Current.GoToAsync(route);
        }
        async Task Remove(Word word)
        {
            await wordService.RemoveWord(word.Id);
            await Refresh();
        }
        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(500);
            WordCol.Clear();
            var words = await wordService.GetEnglishWords();
            WordCol.AddRange(words);
            IsBusy = false;
        }
    }
}
