using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CommerceApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CommerceApp.ViewModels
{
    public class HomeViewModel
    {
        //--------------------- Attributes Section ----------------------------
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Event> Events { get; set; }
        public ObservableCollection<ProductSection> ProductSections { get; set; }

        //---------------------- Process Section -------------------------------
        public Command LoadMoreCategoryCommand { get; }
        public Command LoadMoreProductCommand { get; }
        public Command LoadMoreEventCommand { get; }
        public Command AutoSliderCommand { get; }


        //Constructor
        public HomeViewModel()
        {
            LoadMoreCategoryCommand = new Command(() =>
            {
                Categories.Add(new Category { Name = "New Items", IconUrl = "/apparel.png" });
                Categories.Add(new Category { Name = "New Items", IconUrl = "/apparel.png" });
            });

            LoadMoreProductCommand = new Command<ObservableCollection<Product>>(Products =>
            {
                var categoryid = Products[0].CategoryID;
                Products.Add(new Product { CategoryID = categoryid, IconUrl = "jacket.png", ProductName = "New ID" + categoryid.ToString(), Price = 1500 });
            });

            LoadMoreEventCommand = new Command<ObservableCollection<Event>>(Events =>
            {
                var event_id = Events[Events.Count - 1].ID;
                for (int i = event_id+1; i <= event_id + 5; i++)
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

            ProductSections = new ObservableCollection<ProductSection>
            {
                new ProductSection
                {
                    SectionTitle="Quần áo",
                    Products=new ObservableCollection<Product>
                    {
                        new Product {CategoryID=1,IconUrl="jacket.png",ProductName="Áo thun 1",Price=100},
                        new Product {CategoryID=1,IconUrl="jacket.png",ProductName="Áo thun 2",Price=100},
                        new Product {CategoryID=1,IconUrl="jacket.png",ProductName="Áo thun 3",Price=100},
                        new Product {CategoryID=1,IconUrl="jacket.png",ProductName="Áo thun 4",Price=100},
                        new Product {CategoryID=1,IconUrl="jacket.png",ProductName="Áo thun 5",Price=100}
                    }
                },
                new ProductSection
                {
                    SectionTitle="Mỹ phẩm",
                    Products=new ObservableCollection<Product>
                    {
                        new Product {CategoryID=2,IconUrl="jacket.png",ProductName="Mỹ phẩm 1",Price=100},
                        new Product {CategoryID=2,IconUrl="jacket.png",ProductName="Mỹ phẩm 2",Price=100},
                        new Product {CategoryID=2,IconUrl="jacket.png",ProductName="Mỹ phẩm 3",Price=100},
                        new Product {CategoryID=2,IconUrl="jacket.png",ProductName="Mỹ phẩm 4",Price=100},
                        new Product {CategoryID=2,IconUrl="jacket.png",ProductName="Mỹ phẩm 5",Price=100}
                    }
                },
                new ProductSection
                {
                    SectionTitle="Giày dép",
                    Products=new ObservableCollection<Product>
                    {
                        new Product {CategoryID=3,IconUrl="jacket.png",ProductName="Giày dép 1",Price=100},
                        new Product {CategoryID=3,IconUrl="jacket.png",ProductName="Giày dép 2",Price=100},
                        new Product {CategoryID=3,IconUrl="jacket.png",ProductName="Giày dép 3",Price=100},
                        new Product {CategoryID=3,IconUrl="jacket.png",ProductName="Giày dép 4",Price=100},
                        new Product {CategoryID=3,IconUrl="jacket.png",ProductName="Giày dép 5",Price=100}
                    }
                }
            };
        }
        public class ProductSection
        {
            public string SectionTitle { get; set; }
            public ObservableCollection<Product> Products { get; set; }
        }
    }

}
