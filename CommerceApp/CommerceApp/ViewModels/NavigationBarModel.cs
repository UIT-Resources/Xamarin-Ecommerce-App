using CommerceApp.Models;
using CommerceApp.Views;
using System;
using Xamarin.Forms;
using Newtonsoft.Json;
using CommerceApp.Views;
using CommerceApp.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Collections.ObjectModel;

namespace CommerceApp.ViewModels
{
    public class NavigationBarModel : BindableBase
    {
        bool isAmountGreaterZero;
        public bool IsAmountGreaterZero { get { return isAmountGreaterZero; } set { isAmountGreaterZero = value; OnPropertyChanged("IsAmountGreaterZero"); } }
        int productAmount;
        ObservableCollection<Product> ListProductSearchResult { get; set; }
        public Command GetProductSearchResult { get; }

        public int ProductAmount
        {
            get { return productAmount; }
            set
            {
                //Check Loggined
                if ((App.Database.GetSession(1) is null) || (App.Database.GetSession(1).State == false))
                {
                    Console.WriteLine("*ERROR: Setting Amount Failed. User's not loggined");
                }
                else
                {
                    productAmount = value;
                    if (value > 0) IsAmountGreaterZero = true;
                    else IsAmountGreaterZero = false;
                    OnPropertyChanged("ProductAmount");
                }
            }
        }
        public Command CartClickedCommand { get; }

        public NavigationBarModel()
        {
            LoadCardList();
            CartClickedCommand = new Command(async () =>
            {
                Console.WriteLine("Cart Clicked Command's running");
                if ((App.Database.GetSession(1) is null) || (App.Database.GetSession(1).State == false))
                {
                    Console.WriteLine("*Loading CartPage Failed. User's not loggined");
                    await App.Current.MainPage.DisplayAlert("Lỗi", "Bạn chưa đăng nhập. Vui lòng đăng nhập để sử dụng giỏ hàng!", "OK");
                }
                else
                {
                    await App.Current.MainPage.Navigation.PushModalAsync(new Cart());
                }
            });
            GetProductSearchResult = new Command<string>(async (searchText) =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new SearchPage(searchText));
            });

        }
        public async void LoadCardList()
        {
            Console.WriteLine("LoadCardList's running");
            if ((App.Database.GetSession(1) is null) || (App.Database.GetSession(1).State == false))
            {
                Console.WriteLine("*Error: LoadCardList Fail. User's not loggined");
            }
            else
            {
                Console.WriteLine("LoadCardList's excuting");
                string result = await App.Api.Get($"/user/cart/list/{App.Database.GetSession(1).UserID}");
                Console.WriteLine(result);
                List<ProductOfUser> CardList = JsonConvert.DeserializeObject<List<ProductOfUser>>(result);
                ProductAmount = 0;
                for (int i = 0; i < CardList.Count; i++)
                {
                    ProductAmount += CardList[i].Amount;
                }
            }
        }
        
    }
}
