using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace CommerceApp.Models
{
    public class Event:BindableBase
    {
        int id                {get; set;}
        string description    {get; set;}
        string note           {get; set;}
        DateTime? create_date {get; set;}
        DateTime? update_date {get; set;}
        string routerName     {get; set;}
        int id_root           {get; set;}
        int id_item           {get; set;}
        string items          {get; set;}
        string url_images     {get; set;}
        int status            {get; set;}
        int sort              {get; set;}

        public int ID                { get { return id; }           set { id = value;  OnPropertyChanged("Id"); } }
        public string Description    { get { return description; }  set { description = value;  OnPropertyChanged("Description"); } }
        public string Note           { get { return note; }         set { note = value;  OnPropertyChanged("Note"); } }
        public DateTime? Create_date { get { return create_date; }  set { create_date = value; OnPropertyChanged("CreateDate"); } }
        public DateTime? Update_date { get { return update_date; }  set { update_date = value; OnPropertyChanged("UpdateDate"); } }
        public string RouterName     { get { return routerName; }   set { routerName = value; OnPropertyChanged("RouterName"); } }
        public int Id_root           { get { return id_root; }      set { id_root = value; OnPropertyChanged("Id_root"); } }
        public int Id_item           { get { return id_item; }      set { id_item = value; OnPropertyChanged("Id_item"); } }
        public string Items          { get { return items; }        set { items = value; OnPropertyChanged("Items"); } }
        public string Url_images     { get { return url_images; }   set { url_images = value; OnPropertyChanged("Url_images"); } }
        public int Status            { get { return status; }       set { status = value; OnPropertyChanged("Status"); } }
        public int Sort              { get { return sort; }         set { sort = value; OnPropertyChanged("Sort"); } }

    }
}
