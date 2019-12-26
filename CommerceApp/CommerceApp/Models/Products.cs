using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceApp.Models
{
    public class Products : BindableBase
    {
        int productid;
        string productname;
        float price;
        int categoryid;
        string trademark;
        string madein;
        DateTime warrantytime;
        DateTime manufacturetime;
        float rank;
        string description;
        string iconurl;

        public int ProductID { get { return productid; } set { productid = value; OnPropertyChanged("ProductID"); } }
        public string ProductName { get { return productname; } set { productname = value; OnPropertyChanged("ProductName"); } }
        public float Price { get { return price; } set { price = value; OnPropertyChanged("Price"); } } 
        public int CategoryID { get { return categoryid; } set { categoryid = value; OnPropertyChanged("CategoryID"); } } 
        public string TradeMark { get { return trademark; } set { trademark = value; OnPropertyChanged("TradeMark"); } } 
        public string MadeIn { get { return madein; } set { madein = value; OnPropertyChanged("MadeIn"); } } 
        public DateTime WarrantyTime { get { return warrantytime; } set { warrantytime = value; OnPropertyChanged("WarrantyTime"); } } 
        public DateTime ManufactureTime { get { return manufacturetime; } set { manufacturetime = value; OnPropertyChanged("ManufactureTime"); } } 
        public float Rank { get { return rank; } set { rank = value; OnPropertyChanged("Rank"); } } 
        public string Description { get { return description; } set { description = value; OnPropertyChanged("Description"); } } 
        public string IconUrl { get { return iconurl; } set { iconurl = value; OnPropertyChanged("IconUrl"); } } 

    }
}
