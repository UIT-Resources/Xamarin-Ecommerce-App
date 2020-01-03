﻿
using CommerceApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CommerceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeNavigationBar : ContentView
    {
        public HomeNavigationBar()
        {
            InitializeComponent();
            this.BindingContext = App.navigationBarModel;
        }
    }
}