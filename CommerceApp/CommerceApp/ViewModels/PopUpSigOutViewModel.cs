using CommerceApp.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using CommerceApp.Models;

namespace CommerceApp.ViewModels
{
    class PopUpSigOutViewModel
    {
        public Command co { get; }
        public Command khong { get; }
        public PopUpSigOutViewModel()
        {
            co = new Command(async () =>
           {
               Session current = App.Database.GetSession(1);
               App.Database.DeleteAllSessions();
               App.Database.SaveSession(new Session() { State = false, UserID = current.UserID });
               Session s = App.Database.GetSession(1);
               Application.Current.MainPage.Navigation.InsertPageBefore(new Loggin(), Application.Current.MainPage.Navigation.NavigationStack.Last());
               await Application.Current.MainPage.Navigation.PopAsync();
               await PopupNavigation.PopAsync(true);
           });
            khong = new Command(async () =>
            {
                await PopupNavigation.PopAsync(true);
            });
        }
    }
}
