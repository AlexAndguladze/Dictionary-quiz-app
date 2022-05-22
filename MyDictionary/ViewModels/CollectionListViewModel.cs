using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MyDictionary.Models;
using MyDictionary.Services;
using Xamarin.Forms;

namespace MyDictionary.ViewModels
{
    public class CollectionListViewModel : BaseViewModel
    {/*
        public ObservableRangeCollection<Word> WordCol { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand<object> SelectedCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<Word> RemoveCommand { get; }
        public CollectionListViewModel()
        {
            WordCol = new ObservableRangeCollection<Word>();
            RefreshCommand = new AsyncCommand(Refresh);
            SelectedCommand = new AsyncCommand<object>(Selected);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<Word>(Remove);
        }
        Word selectedWord;
        public Word SelectedWord
        {
            get => selectedWord;
            set => SetProperty(ref selectedWord, value);
            
        }
        async Task Add() 
        {
            var word = await App.Current.MainPage.DisplayPromptAsync("Word", "New Word");
            var phonetic = await App.Current.MainPage.DisplayPromptAsync("Phonetic", "New Word");
            var definiton = await App.Current.MainPage.DisplayPromptAsync("Definition", "Definition of word");
            await WordService.AddWord(word, phonetic, definiton);
            await Refresh();
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
        async Task Remove(Word word)
        {
            await WordService.RemoveWord(word.Id);
            await Refresh();
        }
        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(2000);
            WordCol.Clear();
            var words = await WordService.GetWord();
            WordCol.AddRange(words);
            IsBusy = false;
        }*/
    }
}
