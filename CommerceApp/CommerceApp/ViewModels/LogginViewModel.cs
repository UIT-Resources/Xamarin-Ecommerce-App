using CommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using CommerceApp.Views;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;

namespace CommerceApp.ViewModels
{
    class LogginViewModel : BindableBase
    {
        class tempUser
        {
            public int id { get; set; }
            public string full_name { get; set; }
            public string phone_number { get; set; }
            public string email { get; set; }
            public int point { get; set; }
            public string birthday { get; set; }
            public string create_date { get; set; }
            public string update_date { get; set; }
            public string note { get; set; }
        }
        public User user { get; set; }
        string invalidInput { get; set; }
        public string InvalidInput
        {
            get
            {
                return invalidInput;
            }
            set
            {
                invalidInput = value;
                OnPropertyChanged("InvalidInput");
            }
        }
        public Command checkloggin { get; }
        public Command quenmatkhau { get; }
        public Command dangky { get; }
        public Api api = new Api();
        public Session session = new Session();
        public LogginViewModel(INavigation Navigation)
        {

            user = new User();

            quenmatkhau = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new ForgotPass());
            });
            checkloggin = new Command(async () =>
            {
                //get data user here
                string dataLogin = @"{
                    ""username"":""" + user.UserName + @""",
                    ""password"":""" + user.PassWord + @"""
                    }";
                string dataUser = await api.Post("/user/login", dataLogin);
                tempUser tempuser = new tempUser();
                tempuser = JsonConvert.DeserializeObject<tempUser>(dataUser);

                user.ID = tempuser.id;
                user.UserName = "";
                user.PassWord = "";
                user.BirthDay = Convert.ToDateTime(tempuser.birthday);
                user.PhoneNumber = tempuser.phone_number;
                user.Email = "";
                user.Sex = "";
                user.IconUrl = "";

                session.UserID = tempuser.id;
                session.State = true;

                App.Database.SaveUser(user);
                App.Database.SaveSession(session);
                Console.WriteLine(tempuser.create_date);

                if (tempuser.create_date == null)
                {
                    user.UserName = "";
                    user.PassWord = "";
                    InvalidInput = "UserName hoặc PassWord sai.";
                }
                else
                {
                    Application.Current.MainPage.Navigation.InsertPageBefore(new ControlPage(), Application.Current.MainPage.Navigation.NavigationStack.Last());
                    await Application.Current.MainPage.Navigation.PopAsync();
                }

            });
            dangky = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new SignUp());
            });
        }
    }
}
