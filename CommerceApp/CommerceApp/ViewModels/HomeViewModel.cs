using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CommerceApp.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Newtonsoft.Json;

namespace CommerceApp.ViewModels
{
    public class HomeViewModel:BindableBase
    {
        //--------------------- Attributes Section ----------------------------
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Event> Events { get; set; }
        public ObservableCollection<ProductSection> ProductSections { get; set; }
        public bool isLoadingProductSection { get; set; }
        public bool IsLoadingProductSection { get { return isLoadingProductSection; } set{ isLoadingProductSection = value;OnPropertyChanged("IsLoadingProductSection"); } }

        //---------------------- Process Section -------------------------------
        public Command LoadMoreCategoryCommand { get; }
        public Command LoadMoreProductCommand { get; }
        public Command LoadMoreEventCommand { get; }
        public Command AutoSliderCommand { get; }
        public Command ProductClickedCommand { get; }
        public Command LoadMoreProductSection { get; }


        //Constructor
        public HomeViewModel()
        {
            //Declare Variables
            Events = new ObservableCollection<Event>();
            Categories = new ObservableCollection<Category>();
            ProductSections = new ObservableCollection<ProductSection>();
            IsLoadingProductSection = false;
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
                if (tempCategories.Count <= 0)
                {
                    Console.WriteLine("ERROR: LoadMoreCategoriesCommand with no data. Server responsed no anything");
                }
                else
                {
                    //Add events into Events List. 
                    //Notes : Wrong assign Events = events;
                    for (int i = 0; i < tempCategories.Count; i++)
                    {
                        Categories.Add(tempCategories[i]);
                    }
                    Console.WriteLine("LoadMoreCategoriesCommand has runned");
                    Console.WriteLine(Categories.Count);
                    Console.WriteLine(JsonConvert.SerializeObject(Categories[0]));
                }
            });

            LoadMoreProductCommand = new Command<ObservableCollection<Product>>(Products =>
            {
                if (Products.Count <= 0)
                {
                    Console.WriteLine("ERROR: LoadMoreProductCommand with no data. Server responsed no anything");
                }
                else
                {
                    var categoryid = Products[0].Root_id;
                    Products.Add(new Product { Root_id = categoryid, Url_images = "jacket.png", Full_name = "New ID" + categoryid.ToString(), Cost = 1500 });
                }

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

            ProductClickedCommand = new Command<int>(async (ProductId) =>
           {
                //App.Current.MainPage.Navigation.PushAsync(new DetailProduct(ProductId));
            });

            LoadMoreProductSection = new Command<ObservableCollection<ProductSection>>(async (ProductSections) =>
            {
                //Set Activity Indicator
                IsLoadingProductSection = true;
                //Get more categories from SERVER
                Console.WriteLine("=>>>>LoadMoreProductSectionCommand is running");
                ObservableCollection<ProductSection> temp = new ObservableCollection<ProductSection>();
                temp = await App.ProductSectionManager.RefreshProductSectionAsync();
                if (temp.Count <= 0)
                {
                    Console.WriteLine("ERROR: LoadMoreProductSection with no data. Server responsed no anything");
                }
                else
                {
                    //for (int i = 0; i < temp.Count; i++)
                    //{
                    //    ProductSections.Add(temp[i]);
                    //}
                    //Notes: Thực tế sẽ phải load những danh mục & sản phẩm , tuy nhiên dữ liệu giả lập chưa có nên sẽ load lặp lại , và hiện vẫn cài đặt nhớ phần dữ liệu đã load.
                    //Để test load dữ liệu chỉ load 1 danh mục kèm sản phẩm ngẫu nhiên từ server.
                    int rInt;
                    do
                    {
                        Random r = new Random();
                        rInt = r.Next(0, temp.Count); //for ints
                    } while (temp[rInt].products.Count <= 0);
                    ProductSections.Add(temp[rInt]);
                    Console.WriteLine("LoadMoreProductSection successfully run");
                    Console.WriteLine(ProductSections.Count);
                    Console.WriteLine(JsonConvert.SerializeObject(ProductSections[0]));
                }
                //Set Activity Indicator
                IsLoadingProductSection = false;
            });
        }

    }

}
