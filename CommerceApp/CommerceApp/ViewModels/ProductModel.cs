using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

using System.Runtime.CompilerServices;

using System.Windows.Input;
using CommerceApp.Models;
using Newtonsoft.Json;
using Xamarin.Forms;
using static CommerceApp.ViewModels.HomeViewModel;

namespace CommerceApp.ViewModels

{
    public class ProductModel : INotifyPropertyChanged

    {
        private Product product;
        public ICommand Get { get; set; }
        private ObservableCollection<Images> images;
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Event> Events { get; set; }
        public ObservableCollection<ProductSection> ProductSections { get; set; }

        //---------------------- Process Section -------------------------------
        public Command LoadMoreCategoryCommand { get; }
        public Command LoadMoreProductCommand { get; }
        public Command LoadMoreEventCommand { get; }
        public Command AutoSliderCommand { get; }
        private int id;
        public ProductModel()
        {
            id = 2;
            images = new ObservableCollection<Images>();
            Get = new Command(GetData);
            GetData();
            LoadMoreCategoryCommand = new Command(() =>
            {
                Categories.Add(new Category { Name = "New Items", IconUrl = "/apparel.png" });
                Categories.Add(new Category { Name = "New Items", IconUrl = "/apparel.png" });
            });

            LoadMoreProductCommand = new Command<ObservableCollection<Product>>(Products =>
            {
                var categoryid = Products[0].root_id;
                Products.Add(new Product { root_id = categoryid, url_images = "jacket.png", full_name = "New ID" + categoryid.ToString(), cost = 1500 });
            });

            LoadMoreEventCommand = new Command<ObservableCollection<Event>>(Events =>
            {
                var event_id = Events[Events.Count - 1].ID;
                for (int i = event_id + 1; i <= event_id + 5; i++)
                {
                    Events.Add(new Event { ID = i, Url = "Banner.png" });
                }
            });

            AutoSliderCommand = new Command<int>(Position =>
            {
                Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>)(() =>
                {
                    Position = (Position + 1) % Events.Count;
                    return true;
                }));
            });
            // Create Data For Testing
            Events = new ObservableCollection<Event>
            {
                new Event { ID = 1, Url = "Banner.png" },
                new Event { ID = 2, Url = "Banner.png" },
                new Event { ID = 3, Url = "Banner.png" },
                new Event { ID = 4, Url = "Banner.png" },
                new Event { ID = 5, Url = "Banner.png" }
            };

            Categories = new ObservableCollection<Category>
            {
                new Category {CategoryID=1,Name="Quần áo", IconUrl="/apparel.png"},
                new Category {CategoryID=2,Name="Mỹ phẩm", IconUrl="/beauty.png"},
                new Category {CategoryID=3,Name="Giày dép", IconUrl="/shoes.png"},
                new Category {CategoryID=4,Name="Quần áo 2", IconUrl="/apparel.png"},
                new Category {CategoryID=5,Name="Mỹ phẩm 2", IconUrl="/beauty.png"},
                new Category {CategoryID=6,Name="Giày dép 2", IconUrl="/shoes.png"},
            };
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
            Console.WriteLine("ok 1");
            string result = await App.Api.Get("/product/select/" + id);
            string resultimages = await App.Api.Get("/product/item-images/" + id);
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