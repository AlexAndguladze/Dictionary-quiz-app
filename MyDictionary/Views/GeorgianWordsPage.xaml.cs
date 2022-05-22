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
    public partial class GerogianWordsPage : ContentPage
    {
        GeorgianWordsViewModel vm;
        public GerogianWordsPage()
        {
            InitializeComponent();
            vm = this.BindingContext as GeorgianWordsViewModel;

            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<AddGeorgianWordViewModel>(this, "RefreshGeo", (p) =>
            {
                if ((vm != null) && (vm.RefreshCommand.CanExecute(null)))
                {
                    vm.RefreshCommand.ExecuteAsync();
                }
            });

            if (vm.WordCol.Count == 0)
            {
                if ((vm != null) && (vm.RefreshCommand.CanExecute(null)))
                {
                    vm.RefreshCommand.ExecuteAsync();
                }
                MessagingCenter.Unsubscribe<AddGeorgianWordViewModel>(this, "RefreshGeo");
            }

        }
    }
}