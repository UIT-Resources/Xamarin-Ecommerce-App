using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceApp.Models
{
    public class ProductServer : BindableBase
    {
        public int id { get; set; }
        public string full_name { get; set; }
        public string create_date { get; set; }
        public string update_date { get; set; }
        public string note { get; set; }
        public int root_id { get; set; }
        public double cost { get; set; }
        public string unit { get; set; }
        public string url_images { get; set; }
        public int status { get; set; }
        public double rank { get; set; }
        public string origin { get; set; }
        public string trademark { get; set; }
        public string dateofmanufacture { get; set; }
        public string expirationdate { get; set; }
        public string description { get; set; }
        public int amount { get; set; }

        public int Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
        public string Full_name { get { return full_name; } set { full_name = value; OnPropertyChanged("Full_name"); } }
        public string Create_date { get { return create_date; } set { create_date = value; OnPropertyChanged("Create_date"); } }
        public string Update_date { get { return update_date; } set { update_date = value; OnPropertyChanged("Update_date"); } }
        public string Note { get { return note; } set { note = value; OnPropertyChanged("Note"); } }
        public int Root_id { get { return root_id; } set { root_id = value; OnPropertyChanged("Root_id"); } }
        public double Cost { get { return cost; } set { cost = value; OnPropertyChanged("Cost"); } }
        public string Unit { get { return unit; } set { unit = value; OnPropertyChanged("Unit"); } }
        public string Url_images { get { return url_images; } set { url_images = value; OnPropertyChanged("Url_images"); } }
        public int Status { get { return status; } set { status = value; OnPropertyChanged("Status"); } }
        public double Rank { get { return rank; } set { rank = value; OnPropertyChanged("Rank"); } }
        public string Origin { get { return origin; } set { origin = value; OnPropertyChanged("Origin"); } }
        public string Trademark { get { return trademark; } set { trademark = value; OnPropertyChanged("Trademark"); } }
        public string Dateofmanufacture { get { return dateofmanufacture; } set { dateofmanufacture = value; OnPropertyChanged("Dateofmanufacture"); } }
        public string Expirationdate { get { return expirationdate; } set { expirationdate = value; OnPropertyChanged("Expirationdate"); } }
        public string Description { get { return description; } set { description = value; OnPropertyChanged("Description"); } }
        public int Amount { get { return amount; } set { amount = value; OnPropertyChanged("Amount"); } }
    }
}
