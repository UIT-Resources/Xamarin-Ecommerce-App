using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceApp.Models
{
    class Event:BindableBase
    {
        int id                  { get; set; }
        string full_name        { get; set; }
        string note             { get; set; }
        string url              { get; set; }
        DateTime? create_date    { get; set; }
        DateTime? update_date    { get; set; }
        int create_by           { get; set; }
        int status              { get; set; }

        public int ID { get { return id; } set { id = value; OnPropertyChanged("id"); } }
        public string FullName { get { return full_name; } set { full_name = value; OnPropertyChanged("FullName"); } }
        public string Note { get { return note; } set { note = value; OnPropertyChanged("Note"); } }
        public string Url { get { return url; } set { url = value; OnPropertyChanged("Url"); } }
        public DateTime? CreateDate { get { return create_date; } set { create_date = value; OnPropertyChanged("CreateDate"); } }
        public DateTime? UpdateDate { get { return update_date; } set { update_date = value; OnPropertyChanged("UpdateDate"); } }
        public int CreateBy { get { return create_by; } set { create_by = value; OnPropertyChanged("CreateBy"); } }
        public int Status { get { return status; } set { create_by = value; OnPropertyChanged("Status"); } }
    }
}
