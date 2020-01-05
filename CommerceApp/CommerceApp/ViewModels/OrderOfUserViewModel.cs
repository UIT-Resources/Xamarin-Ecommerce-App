using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CommerceApp.Models;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace CommerceApp.ViewModels
{

    class OrderOfUserViewModel : BindableBase
    {
        public bool isloading { get; set; }
        public bool Isloading { get { return isloading; } set { isloading = value; OnPropertyChanged("Isloading"); } }
        Api api = new Api();
        ObservableCollection<BillOfUser> bills  = new ObservableCollection<BillOfUser>();
        public ObservableCollection<BillOfUser> Bills { get { return bills; } set { bills = value; } }
        public OrderOfUserViewModel()
        {
            deleteallproductCart();
            getDataBills();
            
        }
        public async void getDataBills()
        {
            Isloading = true;
            int userIDcurrent = App.Database.GetSession(1).UserID;
            List<BillOfUser> bills = new List<BillOfUser>();
            string url = $"/user/{userIDcurrent}/bill";
            string data = "";
            data = await api.Get(url);
            bills = JsonConvert.DeserializeObject<List<BillOfUser>>(data);
            if(bills == null)
            {
                return;
            }
            for(int i=0;i< bills.Count; i++)
            {
                if(bills[i] == null)
                {
                    break;
                }
                Bills.Add(bills[i]);
            }
            Isloading = false;
        }
        public List<ProductOfUser> productOfUsers { get; set; }
        public async void deleteallproductCart()
        {
            int useridcurrent = App.Database.GetSession(1).UserID;
            Console.WriteLine($"useridcurrent: {useridcurrent}");
            string data = "";
            data = await api.Get($"/user/cart/list/{useridcurrent}");
            if (data.Equals("[]"))
            {
                return;
            }
            productOfUsers = JsonConvert.DeserializeObject<List<ProductOfUser>>(data);
            for (int j = 0; j < productOfUsers.Count; j++)
            {
                data = "";
                App.navigationBarModel.ProductAmount -= productOfUsers[j].Amount; // Update Product Amount On CartIcon
                int i = -1;
                data = @"{""amount"":" + i + "}";
                await api.Post($"/user/cart/{productOfUsers[j].Id}", data);
            }
        }
    }
}
