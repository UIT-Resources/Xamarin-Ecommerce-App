using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using CommerceApp.Models;
using CommerceApp.Views;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace CommerceApp.ViewModels
{
    class CartViewModel : BindableBase
    {
        public List<ProductServer> productServers { get; set; }
        public List<ProductServer> ProductServers
        {
            get
            {
                return productServers;
            }
            set
            {
                productServers = value;
                OnPropertyChanged("ProductServers");
            }
        }
        public List<ProductOfUser> productOfUsers { get; set; }

        public double total { get; set; }
        public double Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
                OnPropertyChanged("Total");
            }
        }
        public Command thanhtoan { get; }
        public Api api = new Api();
        public async void GetProductOfUser()
        {


            int useridcurrent = App.Database.GetSession(1).UserID;
            Console.WriteLine($"useridcurrent: {useridcurrent}");
            string data = "";
            data = await api.Get($"/user/cart/list/{useridcurrent}");
            productOfUsers = JsonConvert.DeserializeObject<List<ProductOfUser>>(data);
            List<ProductServer> ob = new List<ProductServer>();
            for (int i = 0; i < productOfUsers.Count; i++)
            {
                data = "";
                string url = $"/product/select/{productOfUsers[i].Item_id}";
                data = await api.Get(url);
                ProductServer temp = JsonConvert.DeserializeObject<ProductServer>(data);
                temp.Amount = productOfUsers[i].Amount;
                ob.Add(temp);
            }
            AccoutTotal(ob);
        }
        public void AccoutTotal(List<ProductServer> lps)
        {
            double tempo = 0;
            for (int i = 0; i < lps.Count; i++)
            {
                tempo += lps[i].Cost * lps[i].Amount;
            }
            Total = tempo;
            ProductServers = lps;
        }
        public CartViewModel()
        {
            // get data product of user here
            GetProductOfUser();
            //behavior swicth payment page
            thanhtoan = new Command(() =>
             {
                 App.Current.MainPage.Navigation.PushModalAsync(new PayMent(productOfUsers)); 
             });
        }
        private Command<int> _selectSubstractCommand;
        private Command<int> _selectAddCommand;
        public Command<int> Tru
        {
            get
            {
                return _selectSubstractCommand ?? (_selectSubstractCommand = new Command<int>(async (id) =>
                {
                    for (int j = 0; j < productOfUsers.Count; j++)
                    {
                        if (id == productOfUsers[j].Item_id)
                        {
                            int i = productOfUsers[j].Amount - 1;
                            string data = @"{""amount"":" + i + "}";
                            string product = await api.Post($"/user/cart/{productOfUsers[j].Id}", data);
                            ProductOfUser temp = JsonConvert.DeserializeObject<ProductOfUser>(product);
                            productOfUsers[j] = temp;
                            ProductServers[j].Amount = temp.Amount;
                            AccoutTotal(ProductServers);
                        }
                    }
                }));
            }
        }
        public Command<int> Cong
        {
            get
            {
                return _selectSubstractCommand ?? (_selectSubstractCommand = new Command<int>(async (id) =>
                {
                    for (int j = 0; j < productOfUsers.Count; j++)
                    {
                        if (id == productOfUsers[j].Item_id)
                        {
                            int i = productOfUsers[j].Amount - 1;
                            string data = @"{""amount"":" + i + "}";
                            string product = await api.Post($"/user/cart/{productOfUsers[j].Id}", data);
                            ProductOfUser temp = JsonConvert.DeserializeObject<ProductOfUser>(product);
                            productOfUsers[j] = temp;
                            ProductServers[j].Amount = temp.Amount;
                            AccoutTotal(ProductServers);
                        }
                    }
                }));
            }
        }
    }
}
