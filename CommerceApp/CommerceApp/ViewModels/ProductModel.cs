using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using CommerceApp.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
namespace CommerceApp.ViewModels
{
    public class ProductModel : INotifyPropertyChanged

    {
        Page page;
        private Product product;
        public ICommand PushCart { get; set; }
        private ObservableCollection<Images> images;
        private ObservableCollection<Description> descriptions;
        private Description description;
        private int id;


        //khoa
        public ProductModel(Page page, int idp)
        {
            id = idp;
            this.page = page;
            images = new ObservableCollection<Images>();
            PushCart = new Command(PushCar);
            GetData();
            description = new Description();
        }
        private async void PushCar()
        {
            if ((App.Database.GetSession(1) is null) || (App.Database.GetSession(1).State == false))
            {
                Console.WriteLine("*Loading CartPage Failed. User's not loggined");
                await App.Current.MainPage.DisplayAlert("Lỗi", "Bạn chưa đăng nhập. Vui lòng đăng nhập để chọn mua sản phẩm!", "OK");
            }
            else
            {
                string result = await App.Api.Post($"/user/{App.Database.GetSession(1).UserID}/new-cart/" + id, null);
                Console.WriteLine(result);
                if (result != null)
                {
                    ProductOfUser productOfUser = JsonConvert.DeserializeObject<ProductOfUser>(result);
                    App.navigationBarModel.ProductAmount += 1;
                    Console.WriteLine($"Sucessfully Add Product Id:{id} to Cart");

                }
                else
                {
                    await page.DisplayAlert("Thông báo", " Không thể kết nối đến Server! Vui lòng kiểm tra kết nối Internet", "OK");
                }
            }
        }

        public ObservableCollection<Description> Descriptions
        {
            get { return descriptions; }
            set
            {
                descriptions = value;
                OnPropertyChanged("Descriptions");
            }
        }
        public Description Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
        public Product Product
        {
            get { return product; }
            set
            {
                product = value;
                OnPropertyChanged("Product");
            }
        }

        public ObservableCollection<Images> Sourceimges
        {
            get { return images; }
            set
            {
                images = value;
                OnPropertyChanged("Sourceimges");
            }
        }
        private async void GetData()
        {
            Console.WriteLine($"ProductID: {id}");
            string result = await App.Api.Get("/product/select/" + id);
            string resultimages = await App.Api.Get("/product/item-images/" + id);
            string resultdes = await App.Api.Get("/product/item-description/" + id);
            Descriptions = JsonConvert.DeserializeObject<ObservableCollection<Description>>(resultdes);
            Product = JsonConvert.DeserializeObject<Product>(result);
            Sourceimges = JsonConvert.DeserializeObject<ObservableCollection<Images>>(resultimages);
        }
        // Command="{Binding UpdateTypeFlower}

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

}