﻿using CommerceApp.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using CommerceApp.Views;
using CommerceApp.Models;
using Newtonsoft.Json;
using System.Linq;

namespace CommerceApp.ViewModels
{
    class ProfileViewModel : BindableBase
    {
        public Command dangxuat { get; }
        public Command NavigatedToUserProfileCommand { get; }
        User user { get; set; }
        public User uSer { get { return user; } set { user = value; OnPropertyChanged("uSer"); } }
        string image { get; set; }
        public string Image { get { return image; } set { image = value; OnPropertyChanged("Image"); } }
        string username { get; set; }
        public string UserName { get { return username; } set { username = value; OnPropertyChanged("UserName"); } }
        string email { get; set; }
        public string Email { get { return email; } set { email = value; OnPropertyChanged("Email"); } }
        public Command MyOrder { get; }
        public Command xoabonho { get; }

        Session a = App.Database.GetSession(1);
        public ProfileViewModel(ContentPage CurrentPage)
        {
            uSer = new User();

            List<User> temp = (List<User>)App.Database.GetUsers();

            if (a is null)
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

            if (uSer.IconUrl == "" || uSer.IconUrl.Equals("userdefault.png"))
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
                App.Current.MainPage.Navigation.PushAsync(new UserProfile(uSer));
            });
            dangxuat = new Command(() =>
            {
                PopupNavigation.Instance.PushAsync(new PopUpSigOut());
            });
            xoabonho = new Command(async () =>
            {
                App.Database.DeleteAllUsers();
                App.Database.DeleteAllSessions();
                Application.Current.MainPage.Navigation.InsertPageBefore(new Loggin(), Application.Current.MainPage.Navigation.NavigationStack.Last());
                await Application.Current.MainPage.Navigation.PopAsync();
            });
            MyOrder = new Command(async () =>
            {
                await CurrentPage.Navigation.PushAsync(new OrderOfUser());
            });
        }
    }
}
