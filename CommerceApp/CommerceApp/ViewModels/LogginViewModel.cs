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
        public bool isloading { get; set; }
        public bool Isloading { get { return isloading; } set { isloading = value; OnPropertyChanged("Isloading"); } }
        public LogginViewModel(INavigation Navigation)
        {

            user = new User();

            quenmatkhau = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new ForgotPass());
            });
            checkloggin = new Command(async () =>
            {
                Isloading = true;
                Session sessioncurrent = App.Database.GetSession(1);
                List<User> listuser = (List<User>)App.Database.GetUsers();
                tempUser tempuser = new tempUser();

                string dataLogin = @"{
                    ""username"":""" + user.UserName + @""",
                    ""password"":""" + user.PassWord + @"""
                    }";
                string dataUser = await api.Post("/user/login", dataLogin);

                tempuser = JsonConvert.DeserializeObject<tempUser>(dataUser);

                if (sessioncurrent is null && listuser is null|| sessioncurrent is null && listuser != null|| sessioncurrent != null && listuser is null)
                {
                    App.Database.DeleteAllSessions();

                    user.UserID = tempuser.id;
                    user.UserName = "UserName";
                    user.PassWord = "";
                    user.BirthDay = Convert.ToDateTime(tempuser.birthday);
                    user.PhoneNumber = tempuser.phone_number;
                    user.Email = tempuser.email;
                    user.Sex = "";
                    user.IconUrl = "";

                    session.UserID = tempuser.id;
                    session.State = true;

                    
                    App.Database.SaveUser(user);
                    App.Database.SaveSession(session);
                }
                else
                {
                    if (sessioncurrent.UserID != tempuser.id)
                    {
                        //tài khoản khác
                        int dauhieu = 0;
                        for (int i = 0; i < listuser.Count; i++)
                        {
                            if(tempuser.id == listuser[i].UserID)
                            {
                                dauhieu = 1;
                                App.Database.DeleteAllSessions();
                                App.Database.SaveSession(new Session() { State = true, UserID = listuser[i].UserID });
                                user = listuser[i];
                            }
                        }
                        if(dauhieu == 0)
                        {
                            user.UserID = tempuser.id;
                            user.UserName = "UserName";
                            user.PassWord = "";
                            user.BirthDay = Convert.ToDateTime(tempuser.birthday);
                            user.PhoneNumber = tempuser.phone_number;
                            user.Email = tempuser.email;
                            user.Sex = "";
                            user.IconUrl = "";

                            session.UserID = tempuser.id;
                            session.State = true;

                            App.Database.DeleteAllSessions();
                            App.Database.SaveUser(user);
                            App.Database.SaveSession(session);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < listuser.Count; i++)
                        {
                            if (sessioncurrent.UserID == listuser[i].UserID && sessioncurrent.State == false)
                            {
                                App.Database.DeleteAllSessions();
                                App.Database.SaveSession(new Session() { State = true, UserID = listuser[i].UserID });
                                user = listuser[i];
                            }
                        }
                    }
                }

                Console.WriteLine(tempuser.create_date);

                if (tempuser.create_date == null)
                {
                    user.UserName = "";
                    user.PassWord = "";
                    InvalidInput = "UserName hoặc PassWord sai.";
                    Isloading = false;
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
