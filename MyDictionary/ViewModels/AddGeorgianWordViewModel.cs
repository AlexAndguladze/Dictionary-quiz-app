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
    internal class AddGeorgianWordViewModel:BaseViewModel
    {
        string word, definition;
        public string Word { get => word; set => SetProperty(ref word, value); }
        public string Definition { get => definition; set => SetProperty(ref definition, value); }

        public AsyncCommand saveCommand { get; }
        IWordService wordService;
        public AddGeorgianWordViewModel()
        {
            Title = "სიტყვის დამატება";
            saveCommand = new AsyncCommand(save);
            wordService = DependencyService.Get<IWordService>();
        }
        private async Task save()
        {
            if (String.IsNullOrEmpty(Word) || String.IsNullOrEmpty(Definition))
            {
                return;
            }
            await wordService.AddWord(Word, "", Definition, false);
            await Shell.Current.GoToAsync("..");
            MessagingCenter.Send<AddGeorgianWordViewModel>(this, "RefreshGeo");
        }

    }
}
