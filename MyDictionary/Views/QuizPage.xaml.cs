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
    public partial class QuizPage : ContentPage
    {
        public QuizPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            QuizViewModel vm = this.BindingContext as QuizViewModel;
            if(vm.SwitchEnglish!=false && vm.SwitchGeorgian != false)
            {
                if (vm != null && vm.GenerateQuestionCommand.CanExecute(null))
                {
                    vm.GenerateQuestionCommand.ExecuteAsync();
                }
            }
            
        }
    }
}