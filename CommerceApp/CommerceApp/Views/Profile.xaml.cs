using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CommerceApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
            BindingContext = new ViewModels.ProfileViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //Check isLoggined If = false => Push LogginPage
            if (App.Database.GetSession(1).State == false)
            {
                Console.WriteLine("=>>IsLogged: " + App.Database.GetSession(1).State);
                App.Current.MainPage.Navigation.PushAsync(new Loggin());
            }

        }
    }
    
}