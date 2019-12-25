using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CommerceApp.Views;
using CommerceApp.ViewModels;

namespace CommerceApp
{
    public partial class App : Application
    {
        // Begin Create Local Database (SQLite)
        static ItemRepository database;
        public static ItemRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new ItemRepository();
                }
                return database;
            }
        }
        // End Create Local Database (SQLite)

        public App()
        {
            InitializeComponent();

            MainPage = new PayMent();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
