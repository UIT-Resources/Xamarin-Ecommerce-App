using CommerceApp.Models;
using CommerceApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CommerceApp.ViewModels
{
    class SuccessViewModel
    {
        public Command donhangcuatoi { get; }
        public SuccessViewModel()
        {
            donhangcuatoi = new Command(() =>
            {
                App.Current.MainPage.Navigation.PushModalAsync(new OrderOfUser());
            });
        }
    }
}
