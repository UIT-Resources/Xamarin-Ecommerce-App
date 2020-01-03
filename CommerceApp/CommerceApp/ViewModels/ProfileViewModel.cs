using CommerceApp.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using CommerceApp.Views;
using CommerceApp.Models;
using Newtonsoft.Json;

namespace CommerceApp.ViewModels
{
    class ProfileViewModel : BindableBase
    {
        public Command dangxuat { get; }
        public Command NavigatedToUserProfileCommand { get; }
        public User user { get; set; }
        public User uSer { get { return user; } set { user = value; OnPropertyChanged("uSer"); } }
        public string image { get; set; }
        public string Image { get { return image; } set { image = value; OnPropertyChanged("Image"); } }
        public ProfileViewModel()
        {
            uSer = new User();
            List<User> temp = (List<User>)App.Database.GetUsers();
            uSer = temp[0];
            if (uSer.IconUrl != "")
            {
                Image = "userdefault.png";
            }
            else
            {
                Image = uSer.IconUrl;
            }
            
            NavigatedToUserProfileCommand = new Command(() =>
            {
                App.Current.MainPage.Navigation.PushAsync(new UserProfile());
            });
            dangxuat = new Command(() =>
            {
                PopupNavigation.Instance.PushAsync(new PopUpSigOut());
            });
        }
    }
}
