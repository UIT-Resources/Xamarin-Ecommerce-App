using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceApp.Models
{
    public class Category : BindableBase
    {

        int id { get; set; }
        string full_name { get; set; }
        DateTime? create_date { get; set; }
        DateTime? update_date { get; set; }
        string note { get; set; }
        int status { get; set; }
        string url_images { get; set; }

        public int Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
        public string Full_name { get { return full_name; } set { full_name = value; OnPropertyChanged("Full_name"); } }
        public DateTime? Create_date { get { return create_date; } set { create_date = value; OnPropertyChanged("Create_date"); } }
        public DateTime? Update_date { get { return update_date; } set { update_date = value; OnPropertyChanged("Update_date"); } }
        public string Note { get { return note; } set { note = value; OnPropertyChanged("Note"); } }
        public int Status { get { return status; } set { status = value; OnPropertyChanged("Status"); } }
        public string Url_images { get { return url_images; } set { url_images = value; OnPropertyChanged("Url_images"); } }
    }
}
