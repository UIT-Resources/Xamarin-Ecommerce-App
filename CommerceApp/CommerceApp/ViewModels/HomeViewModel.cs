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
    public class HomeViewModel:BindableBase
    {
        //--------------------- Attributes Section ----------------------------
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<Event> Events { get; set; }
        public ObservableCollection<ProductSection> ProductSections { get; set; }
        bool isLoadingProductSection { get; set; }
        public bool IsLoadingProductSection { get { return isLoadingProductSection; } set{ isLoadingProductSection = value;OnPropertyChanged("IsLoadingProductSection"); } }
        bool isloadingpage { get; set; }
        public bool IsLoadingPage { get { return isloadingpage; } set { isloadingpage = value;OnPropertyChanged("IsLoadingPage"); } }
        bool isready { get; set; }
        public bool IsReady { get { return isready; } set { isready = value;OnPropertyChanged("IsReady"); } }
        

        //---------------------- Process Section -------------------------------
        public Command LoadMoreCategoryCommand { get; }
        public Command LoadMoreProductCommand { get; }
        public Command LoadMoreEventCommand { get; }
        public Command AutoSliderCommand { get; }
        public Command ProductClickedCommand { get; }
        public Command CartClickedCommand { get;  }
        public Command LoadMoreProductSection { get; }


        //Constructor
        public HomeViewModel()
        {
            //Declare Variables
            Events = new ObservableCollection<Event>();
            Categories = new ObservableCollection<Category>();
            ProductSections = new ObservableCollection<ProductSection>();
            IsLoadingProductSection = false;
            IsLoadingPage = true;
            IsReady = false;

            //Dữ liệu được tạo ảo 2 dòng để cho thấy cấu trúc mô phỏng thực tế của app. Vì dữ liệu trên Database không đầy đủ hoặc hình ảnh chưa thêm.
            //Tuy nhiên quá trình tải dữ liệu các danh mục sau đó là hoàn toàn từ server.
            ProductSections.Add(new ProductSection
            {
                category = new Category
                { Full_name = "Category01" },
                products = new ObservableCollection<Product>
                                                        {
                                                            new Product { Id=10,Url_images="jacket.png",Full_name="Product",Cost=100} ,
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
                    Console.WriteLine("LoadMoreCategoriesCommand excuted");
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
               Console.WriteLine("LoadMoreEventCommand excuted");
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
                Console.WriteLine("Product Clicked Command's running");
                await App.Current.MainPage.Navigation.PushAsync(new DetailProduct(ProductId));
            });
            CartClickedCommand = new Command(async () =>
            {
                Console.WriteLine("Cart Clicked Command's running");
                await App.Current.MainPage.Navigation.PushModalAsync(new Cart());
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
                }
                //Set Activity Indicator
                IsLoadingProductSection = false;
            });
            //Set Activity Indicator
            IsLoadingPage = false;
            IsReady = true; ;
        }

    }

}
