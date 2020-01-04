using CommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace CommerceApp.ViewModels
{
    public class SearchViewModel : BindableBase
    {
        //Variables
        bool isfinding { get; set; }
        public bool IsFinding { get { return isfinding; } set { isfinding = value; OnPropertyChanged("IsFinding"); OnPropertyChanged("IsReady"); } }
        public bool IsReady { get { return !IsFinding; } set { isfinding = !value; OnPropertyChanged("IsFinding"); OnPropertyChanged("IsReady"); } }
        bool issearhed { get; set; }
        public bool IsSearched { get { return issearhed; } set { issearhed = value; OnPropertyChanged("IsSearched"); } }
        string searchtext { get; set; }
        public string SearchText { get { return searchtext; } set { searchtext = value; OnPropertyChanged("SearchText"); } }
        int productfoundcount { get; set; }
        public int ProductFoundCount { get { return productfoundcount; } set { productfoundcount = value; OnPropertyChanged("ProductFoundCount"); } }
        ObservableCollection<Product> listproductresultsearch { get; set; }
        public ObservableCollection<Product> ListProductResultSearch { get { return listproductresultsearch; } set { listproductresultsearch = value; OnPropertyChanged("ListProductResultSearch"); ProductFoundCount = listproductresultsearch.Count; } }

        //Commands
        public Command GetProductSearchResult { get; }

        public SearchViewModel(string searchtext)
        {
            IsSearched = false;
            SearchText = searchtext;
            GetProductSearchResult = new Command<string>(async (searchText) =>
            {
                IsSearched = true;
                IsFinding = true;
                SearchText = searchText;
                var result = await App.Api.Get("/api/search?query=" + searchText);
                if (result == null)
                {
                    Console.WriteLine("*ERROR: Can't get data from Server");
                }
                else
                {
                    ListProductResultSearch = JsonConvert.DeserializeObject<ObservableCollection<Product>>(result);
                }
                IsFinding = false;
            });
            if (SearchText != null && SearchText != "")
            {
                GetProductSearchResult.Execute(SearchText); // Execute Finding Progress

            }
            Console.WriteLine("Sucessfully Searched");
        }

    }
}
