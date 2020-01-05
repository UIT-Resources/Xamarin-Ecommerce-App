using CommerceApp.ViewModels;
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
            BindingContext = new ProfileViewModel();
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext= new ProfileViewModel();
            //Check isLoggined If = false => Push LogginPage
            if ((App.Database.GetSession(1) is null) || App.Database.GetSession(1).State == false)
            {
                Console.WriteLine("*Errror: Loading Profile Failed. User's not loggined!!!");
                await App.Current.MainPage.Navigation.PushAsync(new Loggin());
            }
            else
            {
                Console.WriteLine("=>>IsLogged: " + App.Database.GetSession(1).State);
            }
            
        }
    }
    
}