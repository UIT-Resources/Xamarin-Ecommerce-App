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
            OrderItem();
            thanhtoan = new Command(() =>
            {
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
        //string ConvertObjectToString(object obj)
        //{
        //    return obj?.ToString() ?? string.Empty;
        //}
        public async void OrderItem()
        {
            //JArray ArrayorderOfUsers = new JArray();
            //orderOfUser[] ArrayorderOfUsers = new orderOfUser[productOfUsers.Count];
            List<orderOfUser> ListorderOfUsers = new List<orderOfUser>();
            for (int i=0;i<productOfUsers.Count;i++)
            {
                orderOfUser OrDerOfUser = new orderOfUser();
                OrDerOfUser.amount = productOfUsers[i].Amount;
                OrDerOfUser.item_id = productOfUsers[i].Item_id;
                OrDerOfUser.user_id = productOfUsers[i].User_id;
                ListorderOfUsers.Add(OrDerOfUser);
                //ArrayorderOfUsers.Add(OrDerOfUser);
            }
            //JObject o = new JObject();
            //o["MyArray"] = ArrayorderOfUsers;
            //string json = o.ToString();
            //Console.WriteLine($"ffffffffffffffffffffffffffffffffffffffffff{json}");



            //string data = @"{
            //    ""create_by"":""" + productOfUsers[0].User_id + @""",
	           // ""listorder"":"+ ListorderOfUsers +@",
	           // ""recever"":{
		          //  ""name_recever"":"""+ AddressOfUser.Full_name+ @""",
            //        ""phone_recever"":"""+ AddressOfUser.Phone+ @""",
		          //  ""id_address"":1,
		          //  ""note"":"""+ note + @"""}}";
            //string result = await api.Post($"user/{session.UserID}/order", data);
            //await App.Current.MainPage.DisplayAlert($"{result}", "", "Ok");
        }
    }
}
