using CommerceApp.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace CommerceApp.ViewModels
{
    class PopUpSigOutViewModel
    {
        public Command co { get; }
        public Command khong { get; }
        public PopUpSigOutViewModel()
        {
            co = new Command( async () =>
            {
                App.Database.DeleteAllSessions();
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
