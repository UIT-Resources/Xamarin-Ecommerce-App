using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceApp.Models
{
    public class AddressOfUser : BindableBase
    {
        public long id { get; set; }
        public string create_date { get; set; }
        public string update_date { get; set; }
        public string note { get; set; }
        public string province { get; set; }
        public string district { get; set; }
        public string ward { get; set; }
        public string detail { get; set; }
        public int status { get; set; }
        public int user_id { get; set; }
        public string full_name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public long Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
        public string Create_date { get { return create_date; } set { create_date = value; OnPropertyChanged("Create_date"); } }
        public string Update_date { get { return update_date; } set { update_date = value; OnPropertyChanged("Update_date"); } }
        public string Note { get { return note; } set { note = value; OnPropertyChanged("Note"); } }
        public string Province { get { return province; } set { province = value; OnPropertyChanged("Province"); } }
        public string District { get { return district; } set { district = value; OnPropertyChanged("District"); } }
        public string Ward { get { return ward; } set { ward = value; OnPropertyChanged("Ward"); } }
        public string Detail { get { return detail; } set { detail = value; OnPropertyChanged("Detail"); } }
        public int Status { get { return status; } set { status = value; OnPropertyChanged("Status"); } }
        public int User_id { get { return user_id; } set { user_id = value; OnPropertyChanged("User_id"); } }
        public string Full_name { get { return full_name; } set { full_name = value; OnPropertyChanged("Full_name"); } }
        public string Phone { get { return phone; } set { phone = value; OnPropertyChanged("Phone"); } }
        public string Address { get { return address; } set { address = value; OnPropertyChanged("Address"); } }
    }
}
