using Rg.Plugins.Popup.Services;
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
    public partial class Notification : ContentPage
    {
        public Notification()
        {
            InitializeComponent();
            t[] test = new t[] { new t { title = "Đơn hàng #123 củaffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff bạn đã được giao thành công.", time= "Tue 6 Nov, 09:30 - 10:00 GMT" }, new t { title = "Đơn hàng #123 của bạn đã được giao thành công.", time = "Tue 6 Nov, 09:30 - 10:00 GMT" } };
            List.ItemsSource = test;


            
        }
        public class t { 
            public string title { get; set; }
            public string time { get; set; }
        }

        private void showoptionnotify(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new PopUpOptionNotification());
        }
    }
}