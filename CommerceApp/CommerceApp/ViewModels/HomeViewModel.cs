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
        //EventSection[] Events;
        public ObservableCollection<ProductSection> ProductSections { get; set; }

        //---------------------- Process Section -------------------------------
        public Command LoadNewCategory { get; }
        public Command LoadNewProduct { get; }


        //Constructor
        public HomeViewModel()
        {
            LoadNewCategory = new Command(() =>
            {
                Categories.Add(new Category { Name = "New Items 01", IconUrl = "/apparel.png" });
                Categories.Add(new Category { Name = "New Items 02", IconUrl = "/apparel.png" });
            });

            LoadNewProduct = new Command<ObservableCollection<Product>>(Products =>
            {
                var categoryid = Products[0].CategoryID;
                Products.Add(new Product { CategoryID = categoryid, IconUrl = "jacket.png", ProductName = "New ID" + categoryid.ToString(), Price = 1500 });
            });

            // Create Data For Testing
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
