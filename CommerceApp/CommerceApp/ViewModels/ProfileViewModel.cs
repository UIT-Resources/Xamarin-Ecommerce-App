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
        public string username { get; set; }
        public string UserName { get { return username; } set { username = value; OnPropertyChanged("UserName"); } }
        public string email { get; set; }
        public string Email { get { return email; } set { email = value; OnPropertyChanged("Email"); } }
        public Command MyOrder { get; }
        Session a = App.Database.GetSession(1);
        public ProfileViewModel()
        {
            uSer = new User();
            List<User> temp = (List<User>)App.Database.GetUsers();
            
            if(a is null)
            {
                Image = "userdefault.png";
                UserName = "UserName";
                Email = "Email@gmail.com";
                return;
            }
            else
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    if (a.UserID == temp[i].UserID)
                    {
                        uSer = temp[i];
                    }
                }
            }
            


            if (uSer.IconUrl == "")
            {
                Image = "userdefault.png";
            }
            else
            {
                Image = uSer.IconUrl;
            }
            UserName = uSer.UserName;
            Email = uSer.Email;
            NavigatedToUserProfileCommand = new Command(() =>
            {
                App.Current.MainPage.Navigation.PushAsync(new UserProfile());
            });
            dangxuat = new Command(() =>
            {
                PopupNavigation.Instance.PushAsync(new PopUpSigOut());
            });
            MyOrder = new Command(() =>
            {
                App.Current.MainPage.Navigation.PushAsync(new OrderOfUser());
            });
        }
    }
}
