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
        float cost { get; set; }
        string unit { get; set; }
        string url_images { get; set; }
        int status { get; set; }
        int rank { get; set; }
        string origin { get; set; }
        string trademark { get; set; }
        DateTime? dateofmanufacture { get; set; }
        DateTime? expirationdate { get; set; }
        string description { get; set; }

        public int Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
        public string Full_name { get { return full_name; } set { full_name = value; OnPropertyChanged("Full_name"); } }
        public DateTime? Create_date { get { return create_date; } set { create_date = value; OnPropertyChanged("Create_date"); } }
        public DateTime? Update_date { get { return update_date; } set { update_date = value; OnPropertyChanged("Update_date"); } }
        public string Note { get { return note; } set { note = value; OnPropertyChanged("Note"); } }
        public int Root_id { get { return root_id; } set { root_id = value; OnPropertyChanged("Root_id"); } }
        public float Cost { get { return cost; } set { cost = value; OnPropertyChanged("Cost"); } }
        public string Unit { get { return unit; } set { unit = value; OnPropertyChanged("Unit"); } }
        public string Url_images { get { return url_images; } set { url_images = value; OnPropertyChanged("Url_images"); } }
        public int Status { get { return status; } set { status = value; OnPropertyChanged("Status"); } }
        public int Rank { get { return rank; } set { rank = value; OnPropertyChanged("Rank"); } }
        public string Origin { get { return origin; } set { origin = value; OnPropertyChanged("Origin"); } }
        public string Trademark { get { return trademark; } set { trademark = value; OnPropertyChanged("Trademark"); } }
        public DateTime? Dateofmanufacture { get { return dateofmanufacture; } set { dateofmanufacture = value; OnPropertyChanged("Dateofmanufacture"); } }
        public DateTime? Expirationdate { get { return expirationdate; } set { expirationdate = value; OnPropertyChanged("Expirationdate"); } }
        public string Description { get { return description; } set { description = value; OnPropertyChanged("Description"); } }

    }
}