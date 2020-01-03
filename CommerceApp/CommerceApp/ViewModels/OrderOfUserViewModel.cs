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
            Isloading = true;
            getDataBills();
            Isloading = false;
        }
        public async void getDataBills()
        {
            
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
        }
    }
}
