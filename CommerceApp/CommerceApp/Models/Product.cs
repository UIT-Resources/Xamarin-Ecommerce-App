using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceApp.Models
{
    public class Product : BindableBase
    {
         int id { get; set; }
         string full_name { get; set; }
         DateTime? create_date { get; set; }
         DateTime? update_date { get; set; }
         string note { get; set; }
         int root_id { get; set; }
         double cost { get; set; }
         string unit { get; set; }
         string url_images { get; set; }
         int status { get; set; }
         double rank { get; set; }
         string origin { get; set; }
         string trademark { get; set; }
         DateTime? dateofmanufacture { get; set; }
         DateTime? expirationdate { get; set; }
         string description { get; set; }
        public int ID { get { return id; } set { id = value; OnPropertyChanged("ProductID"); } }
        public string Name { get { return full_name; } set { full_name = value; OnPropertyChanged("ProductName"); } }
        public double Cost { get { return cost; } set { cost = value; OnPropertyChanged("Price"); } } 
        public int RootID { get { return root_id; } set { root_id = value; OnPropertyChanged("CategoryID"); } } 
        public string TradeMark { get { return trademark; } set { trademark = value; OnPropertyChanged("TradeMark"); } } 
        public string Origin { get { return origin; } set { origin = value; OnPropertyChanged("MadeIn"); } } 
        public DateTime? Expirationdate { get { return expirationdate; } set { expirationdate = value; OnPropertyChanged("WarrantyTime"); } } 
        public DateTime? Dateofmanufacture { get { return dateofmanufacture; } set { dateofmanufacture = value; OnPropertyChanged("ManufactureTime"); } } 
        public double Rank { get { return rank; } set { rank = value; OnPropertyChanged("Rank"); } } 
        public string Description { get { return description; } set { description = value; OnPropertyChanged("Description"); } } 
        public string Url_images { get { return url_images; } set { url_images = value; OnPropertyChanged("IconUrl"); } } 

    }
}
