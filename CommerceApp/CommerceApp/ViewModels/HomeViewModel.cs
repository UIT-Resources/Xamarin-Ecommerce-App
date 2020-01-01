using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CommerceApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Newtonsoft.Json;

using CommerceApp.Views;

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
        public Command ProductClickedCommand { get; }
        public Command CartClickedCommand { get;  }


        //Constructor
        public HomeViewModel()
        {
            //Declare Variables
            Events = new ObservableCollection<Event>();
            Categories = new ObservableCollection<Category>();
            ProductSections = new ObservableCollection<ProductSection>();
            ProductSections.Add(new ProductSection
            {
                category = new Category
                { Full_name = "Category01" },
                products = new ObservableCollection<Product>
                                                        {
                                                            new Product { Id=1,Url_images="jacket.png",Full_name="Product",Cost=100} ,
                                                            new Product { Id=2,Url_images="jacket.png",Full_name="Product",Cost=100} ,
                                                            new Product { Id=3,Url_images="jacket.png",Full_name="Product",Cost=100}
                                                        }
            });
            ProductSections.Add(new ProductSection
            {
                category = new Category
                { Full_name = "Category02" },
                products = new ObservableCollection<Product>
                                                        {
                                                            new Product { Id=3,Url_images="jacket.png",Full_name="Product",Cost=100} ,
                                                            new Product { Id=4,Url_images="jacket.png",Full_name="Product",Cost=100} ,
                                                            new Product { Id=5,Url_images="jacket.png",Full_name="Product",Cost=100}
                                                        }
            });


            LoadMoreCategoryCommand = new Command<ObservableCollection<Category>>(async (Categories) =>
            {
                //Get more categories from SERVER
                ObservableCollection<Category> tempCategories = new ObservableCollection<Category>();
                tempCategories = await App.CategoryManager.RefreshCategoryAsync();

                //Add events into Events List. 
                //Notes : Wrong assign Events = events;
                for (int i = 0; i < tempCategories.Count; i++)
                {
                    Categories.Add(tempCategories[i]);
                }
                Console.WriteLine("LoadMoreCategoriesCommand has runned");
                Console.WriteLine(JsonConvert.SerializeObject(Categories[0]));
                Console.WriteLine(Categories.Count);
            });

            LoadMoreProductCommand = new Command<ObservableCollection<Product>>(Products =>
            {
                var categoryid = Products[0].Root_id;
                Products.Add(new Product { Root_id = categoryid, Url_images = "jacket.png", Full_name = "New ID" + categoryid.ToString(), Cost = 1500 });
            });

            LoadMoreEventCommand = new Command<ObservableCollection<Event>>(async (Events) =>
           {
                //Get more events from SERVER
                ObservableCollection<Event> tempEvents = new ObservableCollection<Event>();
               tempEvents = await App.EventManager.RefreshEventAsync();

                //Add events into Events List. 
                //Notes : Wrong assign Events = events;
                for (int i = 0; i < tempEvents.Count; i++)
               {
                   Events.Add(tempEvents[i]);
               }
               Console.WriteLine("LoadMoreEventCommand has runned");
               Console.WriteLine(JsonConvert.SerializeObject(Events[0]));
               Console.WriteLine(Events.Count);
           });

            AutoSliderCommand = new Command<int>(Position =>
            {
                Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>)(() =>
                {
                    Position = (Position + 1) % Events.Count;
                    return true;
                }));
            });

            ProductClickedCommand = new Command<int>( async (ProductId) =>
            {

                //await App.Current.MainPage.Navigation.PushAsync(new DetailProduct(ProductId));
            });
            CartClickedCommand = new Command(async () =>
            {
                Console.WriteLine("Cart Clicked Command's running");
                await App.Current.MainPage.Navigation.PushModalAsync(new Cart());
            });
        }
        public class ProductSection
        {
            public Category category { get; set; }
            public ObservableCollection<Product> products { get; set; }

        }
    }

}
