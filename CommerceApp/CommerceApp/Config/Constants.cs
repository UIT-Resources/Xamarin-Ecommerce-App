using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CommerceApp.Config
{
    public static class Constants
    {
        // The iOS simulator can connect to localhost. However, Android emulators must use the 10.0.2.2 special alias to your host loopback interface.
        public static string BaseAddress = "http://uit-api-xamarin.azurewebsites.net";
        public static string CategoriesUrl = BaseAddress + "/product/select/all-category/{0}";
        public static string EventsUrl = BaseAddress + "/api/advertisement/select/{0}";
        public static string ProductsUrl = BaseAddress + "/product/select/{0}";
    }
}
