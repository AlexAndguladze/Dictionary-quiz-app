
using MyDictionary.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MyDictionary
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddEnglishWordPage), typeof(AddEnglishWordPage));
            Routing.RegisterRoute(nameof(AddGeorgianWordPage), typeof(AddGeorgianWordPage));

        }

    }
}
