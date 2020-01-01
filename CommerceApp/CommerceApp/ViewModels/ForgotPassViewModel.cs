using CommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using CommerceApp.Models;
namespace CommerceApp.ViewModels
{
    class ForgotPassViewModel : BindableBase
    {
        string quenmatkhau { get; set; }
        public string QuenMatKhau
        {
            get
            {
                return quenmatkhau;
            }
            set
            {
                quenmatkhau = value;
                OnPropertyChanged("QuenMatKhau");
            }
        }
        public Command email { get; }
        public Api api = new Api();
        public ForgotPassViewModel()
        {
            email = new Command(async () =>
            {
                //string jsonData = @"{""username"" : ""myusername"", ""password"" : ""mypassword""}";
                
                QuenMatKhau = @"{""email"":""" + QuenMatKhau + @""" }";
                Console.WriteLine(QuenMatKhau);


                //string result = await api.Post("/user/forgotpassword", QuenMatKhau);
                await api.Post("/user/forgotpassword", QuenMatKhau);
                await Application.Current.MainPage.DisplayAlert("Thông báo", "Xin hãy kiểm tra thông tin Email", "Ok");
                QuenMatKhau = "";
            });
        }
    }  
}
