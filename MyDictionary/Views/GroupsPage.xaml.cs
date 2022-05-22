using MvvmHelpers;
using MyDictionary.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyDictionary.Views
{
    public partial class GroupsPage : ContentPage
    {
       

        public GroupsPage()
        {
            InitializeComponent();
        }
        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            var details = e.Item as Grouping<string, Word>;
            await Navigation.PushAsync(new CollectionListPage(details.Key, details.Items));
            
        }
    }
}
