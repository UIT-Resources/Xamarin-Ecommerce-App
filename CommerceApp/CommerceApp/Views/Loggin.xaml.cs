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
    public partial class Loggin : ContentPage
    {
        public Loggin()
        {
            InitializeComponent();
            
            quenmatkhau.Clicked += (sender, args) =>
            {
                Navigation.PushModalAsync(new ForgotPass());
            };
            dangnhap.Clicked += (sender, args) =>
            {
                string username = tendangnhap.Text;
                string password = matkhau.Text;
                if (tendangnhap.Text.Length > 0)
                {
                    DisplayAlert("Notification", "Username required", "Close");
                    tendangnhap.Focus();
                }
                if (matkhau.Text.Length > 0)
                {
                    DisplayAlert("Notification", "PassWord required", "Close");
                    matkhau.Focus();
                }

                Console.WriteLine(username, password);
            };
        }
    }
}