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
    class ProfileViewModel
    {
        public Command dangxuat { get; }
        public ProfileViewModel()
        {
            

            dangxuat = new Command(() =>
            {
                PopupNavigation.Instance.PushAsync(new PopUpSigOut());
            });
        }
    }
}
