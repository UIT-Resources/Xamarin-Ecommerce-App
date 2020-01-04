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
        public bool isloading { get; set; }
        public bool Isloading { get { return isloading; } set { isloading = value; OnPropertyChanged("Isloading"); } }
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

            Isloading = true;
            int useridcurrent = App.Database.GetSession(1).UserID;
            Console.WriteLine($"useridcurrent: {useridcurrent}");
            string data = "";
            data = await api.Get($"/user/cart/list/{useridcurrent}");
            if (data.Equals("[]"))
            {
                IsVisiblePayment = false;
                IsVisibleNotify = true;
            }
            productOfUsers = JsonConvert.DeserializeObject<List<ProductOfUser>>(data);
            List<ProductServer> ob = new List<ProductServer>();
            for (int i = 0; i < productOfUsers.Count; i++)
            {
                data = "";
                string url = $"/product/select/{productOfUsers[i].Item_id}";
                data = await api.Get(url);
                ProductServer temp = JsonConvert.DeserializeObject<ProductServer>(data);
                if (temp == null)
                {
                    break;
                }
                temp.Amount = productOfUsers[i].Amount;
                ob.Add(temp);
            }
            AccoutTotal(ob);
            Isloading = false;
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
        public bool isVisiblePayment { get; set; }
        public bool IsVisiblePayment { get { return isVisiblePayment; } set { isVisiblePayment = value; OnPropertyChanged("IsVisiblePayment"); } }
        public bool isVisibleNotify { get; set; }
        public bool IsVisibleNotify { get { return isVisibleNotify; } set { isVisibleNotify = value; OnPropertyChanged("IsVisibleNotify"); } }
        public CartViewModel()
        {
            IsVisiblePayment = true;
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
        private Command<int> _selectDeleteCommand;

        public Command<int> Delete
        {
            get
            {
                return _selectDeleteCommand ?? (_selectDeleteCommand = new Command<int>(async (id) =>
                {
                    for (int j = 0; j < productOfUsers.Count; j++)
                    {
                        if (id == productOfUsers[j].Item_id)
                        {
                            App.navigationBarModel.ProductAmount -= productOfUsers[j].Amount;
                            int i = -1;
                            string data = @"{""amount"":" + i + "}";
                            await api.Post($"/user/cart/{productOfUsers[j].Id}", data);
                            GetProductOfUser();
                        }
                    }
                }));
            }
        }

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
                            App.navigationBarModel.ProductAmount -= 1; // Update Product Amount On CartIcon
                            string data = @"{""amount"":" + i + "}";
                            string product = await api.Post($"/user/cart/{productOfUsers[j].Id}", data);
                            ProductOfUser temp = JsonConvert.DeserializeObject<ProductOfUser>(product);
                            productOfUsers[j] = temp;
                            ProductServers[j].Amount = temp.Amount;
                            AccoutTotal(ProductServers);
                            if (i == 0)
                            {
                                i = -1;
                                data = @"{""amount"":" + i + "}";
                                await api.Post($"/user/cart/{productOfUsers[j].Id}", data);
                                GetProductOfUser();
                            }
                        }
                    }
                }));
            }
        }
        public Command<int> Cong
        {
            get
            {
                return _selectAddCommand ?? (_selectAddCommand = new Command<int>(async (id) =>
                {
                    for (int j = 0; j < productOfUsers.Count; j++)
                    {
                        if (id == productOfUsers[j].Item_id)
                        {
                            int i = productOfUsers[j].Amount + 1;
                            App.navigationBarModel.ProductAmount += 1; // Update Product Amount On CartIcon
                            string data = @"{""amount"":" + i + "}";
                            string product = await api.Post($"/user/cart/{productOfUsers[j].Id}", data);
                            ProductOfUser temp = JsonConvert.DeserializeObject<ProductOfUser>(product);
                            productOfUsers[j] = temp;
                            ProductServers[j].Amount = temp.Amount;
                            AccoutTotal(ProductServers);
                            if (i == 0)
                            {
                                i = -1;
                                data = @"{""amount"":" + i + "}";
                                await api.Post($"/user/cart/{productOfUsers[j].Id}", data);
                                GetProductOfUser();
                            }
                        }
                    }
                }));
            }
        }
    }
}
