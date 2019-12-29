﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CommerceApp.Config
{
    public static class Constants
    {
        // The iOS simulator can connect to localhost. However, Android emulators must use the 10.0.2.2 special alias to your host loopback interface.
        public static string BaseAddress = Device.RuntimePlatform == Device.Android ? "https://10.0.2.2:5001" : "https://localhost:5001";
        public static string CategoriesUrl = BaseAddress + "/api/todoitems/{0}";
        public static string EventsUrl = BaseAddress + "/api/todoitems/{0}";
        public static string ProductsUrl = BaseAddress + "/api/todoitems/{0}";
    }
}