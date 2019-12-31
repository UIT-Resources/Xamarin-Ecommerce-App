using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CommerceApp.Views;
using CommerceApp.ViewModels;
using CommerceApp.Models;
using CommerceApp.Views.Product;

namespace CommerceApp
{
    public partial class App : Application
    {
        // Begin Create Local Database (SQLite)
        static ItemRepository database;
        static RestApi resApi;
        public static RestApi Api { get
            {
                if(resApi==null)
                {
                    resApi = new RestApi();
                }
                return resApi;
            } }
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

            MainPage = new DetailProduct(2);
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
        //khoa
    }
}
