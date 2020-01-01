using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CommerceApp.ViewModels;

namespace CommerceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeNavigationBar : ContentView
    {
        public HomeNavigationBar()
        {
            InitializeComponent();
            this.BindingContext = new HomeViewModel();
        }
    }
}