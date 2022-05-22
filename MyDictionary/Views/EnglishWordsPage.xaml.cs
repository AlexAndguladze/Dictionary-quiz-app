using MyDictionary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyDictionary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnglishWordsPage : ContentPage
    {
        public EnglishWordsPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            EnglishWordsViewModel vm = this.BindingContext as EnglishWordsViewModel;
            if (vm.WordCol.Count == 0)
            {
                if ((vm != null) && (vm.RefreshCommand.CanExecute(null)))
                {
                    vm.RefreshCommand.ExecuteAsync();
                }
            }
            MessagingCenter.Subscribe<AddEnglishWordViewModel>(this, "RefreshEng", (p) =>
            {
                if ((vm != null) && (vm.RefreshCommand.CanExecute(null)))
                {
                    vm.RefreshCommand.ExecuteAsync();
                }
                MessagingCenter.Unsubscribe<AddEnglishWordViewModel>(this, "RefreshEng");
            });
        }
        
    }
}