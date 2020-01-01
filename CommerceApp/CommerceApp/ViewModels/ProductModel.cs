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
        public ProductModel(Page page,int idp)
        {
            id = idp;
            this.page =page;
            images = new ObservableCollection<Images>();
            PushCart = new Command(PushCar);
            GetData();
            // Create Data For Testing
            //descriptions = new ObservableCollection<Description>();
            description = new Description();
            //{
            //    new Images { id = 1, url = "Banner.png" },
            //    new Images { id = 2, url = "Banner.png" },
            //    new Images { id = 3, url = "Banner.png" },
            //    new Images { id = 4, url = "Banner.png" },
            //    new Images { id = 5, url = "Banner.png" }
            //};
        }
        private async void PushCar()
        {
            string result = await App.Api.Post("/user/31/new-cart/" + id,null);
            Console.WriteLine(result);
            if(result=="true")
            {
                await page.DisplayAlert("Thong bao", "Ban da them vao gi hang thanh cong", "OK");
            }
            else
            {
                await page.DisplayAlert("Thong bao", "Co loi xay ra! Ma loi:"+result, "OK");
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