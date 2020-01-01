using CommerceApp.Models;
using CommerceApp.Views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace CommerceApp.ViewModels
{
    class PayMentViewModel : BindableBase
    {
        class orderOfUser
        {
            public int user_id { get; set; }
            public int item_id { get; set; }
            public int amount { get; set; }
        }
        class order
        {
            public string create_by { get; set; }
            public List<orderOfUser> listorder { get; set; }
            public Recever recever { get; set; }
        }
        class Recever
        {
            public string name_recever { get; set; }
            public string phone_recever { get; set; }
            public int id_address { get; set; }
            public string note { get; set; }
        }
        Api api = new Api();
        public Session session;
        public List<AddressOfUser> alladdressOfUser { get; set; }
        public AddressOfUser addressOfUser { get; set; }
        public AddressOfUser AddressOfUser
        {
            get
            {
                return addressOfUser;
            }
            set
            {
                addressOfUser = value;
                OnPropertyChanged("AddressOfUser");
            }
        }
        public List<ProductOfUser> productOfUsers { get; set; }
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
        public string note { get; set; }
        public PayMentViewModel(List<ProductOfUser> productOfUsers)
        {
            session = App.Database.GetSession(1);
            GetProductOfUser(productOfUsers);
            GetAddressUser();
            thanhtoan = new Command(() =>
            {
                OrderItem();
                App.Current.MainPage.Navigation.PushModalAsync(new Success());
            });
        }
        public async void GetAddressUser()
        {

            string data = await api.Get($"/user/address/{session.UserID}");
            alladdressOfUser = JsonConvert.DeserializeObject<List<AddressOfUser>>(data);
            AddressOfUser temp = alladdressOfUser[0];
            temp.Address = $"{temp.Detail}, {temp.Ward}, quận {temp.District}, {temp.Province}";
            AddressOfUser = temp;
        }
        public async void GetProductOfUser(List<ProductOfUser> productOfUser)
        {
            Console.WriteLine("GetProductOfUser");

            string data = "";
            productOfUsers = productOfUser;
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
        
        public async void OrderItem()
        {
            List<orderOfUser> ListorderOfUsers = new List<orderOfUser>();
            for (int i = 0; i < productOfUsers.Count; i++)
            {
                orderOfUser OrDerOfUser = new orderOfUser();
                OrDerOfUser.amount = productOfUsers[i].Amount;
                OrDerOfUser.item_id = productOfUsers[i].Item_id;
                OrDerOfUser.user_id = productOfUsers[i].User_id;
                ListorderOfUsers.Add(OrDerOfUser);
            }
         

            if (note == null)
            {
                note = "";
            };
            order data = new order();
            data.create_by = productOfUsers[0].User_id.ToString();
            data.listorder = ListorderOfUsers;
            Recever temp = new Recever();
            temp.name_recever = AddressOfUser.Full_name;
            temp.phone_recever = AddressOfUser.Phone;
            temp.id_address = Convert.ToInt32(AddressOfUser.Id);
            temp.note = note;
            data.recever = temp;
            Console.WriteLine($"id_address -------------------------------------  {AddressOfUser.Id}");

            string json = JsonConvert.SerializeObject(data);
            Console.WriteLine(json);
            await api.Post($"/user/{session.UserID}/order", json);
        }
    }
}
