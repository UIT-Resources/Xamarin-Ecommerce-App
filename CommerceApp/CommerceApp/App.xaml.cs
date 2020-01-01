﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CommerceApp.Views;
using CommerceApp.ViewModels.DataManager;
using CommerceApp.ViewModels;
using CommerceApp.Models;
using System.Collections.Generic;

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

        // Begin Create WebAPI
        static RestServiceGeneric service;
        public static RestServiceGeneric Service
        {
            get
            {
                if (service == null)
                {
                    service = new RestServiceGeneric();
                }
                return service;
            }
        }

        static ProductManager product_manager; 
        public static ProductManager ProductManager
        {
            get
            {
                if (product_manager == null)
                {
                    product_manager = new ProductManager(Service);
                }
                return product_manager;
            }
        }
        static EventManager event_manager;
        public static EventManager EventManager
        {
            get
            {
                if (event_manager == null)
                {
                    event_manager = new EventManager(Service);
                }
                return event_manager;
            }
        }

        static CategoryManager category_manager;
        public static CategoryManager CategoryManager
        {
            get
            {
                if (category_manager == null)
                {
                    category_manager = new CategoryManager(Service);
                }
                return category_manager;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new ControlPage();
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
