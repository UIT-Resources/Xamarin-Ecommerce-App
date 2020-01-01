using CommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using CommerceApp.Models;
using CommerceApp.Views;

namespace CommerceApp.ViewModels
{
    class SignUpViewModel : BindableBase
    {
        public User user { get; set; }
        public Command dangky { get; }
        public string confirmpassword { get; set; }
        public Api api;
        public string ConFirmPassWord
        {
            get
            {
                return confirmpassword;
            }
            set
            {
                confirmpassword = value;
                OnPropertyChanged("ConFirmPassWord");
            }
        }
        public SignUpViewModel()
        {
            api = new Api();
            user = new User();
            dangky = new Command(async () =>
            {
                if (!user.PassWord.Equals(ConFirmPassWord))
                {
                    await Application.Current.MainPage.DisplayAlert("Thông báo", "Mật khẩu xác thực không chính xác!", "OK");
                    return;
                }
                //string dataUser = @"{
                //                    ""account"":{""username"":""khoa123"",""password"":""khoa123""},
                //                 ""inforuser"":{
                //                                    ""full_name"":""Bui Dang Khoa test"",
                //                  ""email"":""khoaprolaydo@gmail.com"",
                //                  ""birthday"":""1998-07-08"",
                //                  ""phone"":""096936255301""}}";


                string dataUser = @"{""account"":{""username"":""" + user.UserName + @""",
                                    ""password"":""" + user.PassWord + @"""}," + @"""inforuser"":{""full_name"":"""",""email"":""" + user.Email + @""",
                                    ""birthday"":""1970-01-01"",""phone"":""" + user.PhoneNumber + @"""}}";

                Console.WriteLine(dataUser);
                string result = await api.Post("/user/register", dataUser);
                Console.WriteLine(result);
                if (result.Equals("0"))
                {
                    await Application.Current.MainPage.DisplayAlert("Thông báo", "Đăng ký thành công!", "OK");
                    await Application.Current.MainPage.Navigation.PushModalAsync(new Loggin());
                }
                else if(result.Equals("1"))
                {
                    await Application.Current.MainPage.DisplayAlert("Thông báo", "Tài khoản đã tồn tại!", "OK");
                    return;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Thông báo", "Tài khoản đã có!", "OK");
                    return;
                }

            });
        }
    }
}
