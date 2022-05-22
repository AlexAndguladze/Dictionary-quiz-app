using MyDictionary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyDictionary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollectionListPage : ContentPage
    {
        
        public CollectionListPage(string key, IList<Word>WordList)
        {
            InitializeComponent();
            CurrentList.ItemsSource = WordList;
            Title = key;


        }
    }
}