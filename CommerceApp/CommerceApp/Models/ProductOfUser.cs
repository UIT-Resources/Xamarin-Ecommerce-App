using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceApp.Models
{
    public class ProductOfUser : BindableBase
    {
         Int64 id { get; set; }
         int user_id { get; set; }
         int item_id { get; set; }
         string create_date { get; set; }
         int amount { get; set; }
         int status { get; set; }

        public Int64 Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
        public int User_id { get { return user_id; } set { user_id = value; OnPropertyChanged("User_id"); } }
        public int Item_id { get { return item_id; } set { item_id = value; OnPropertyChanged("Item_id"); } }
        public string Create_date { get { return create_date; } set { create_date = value; OnPropertyChanged("Create_date"); } }
        public int Amount { get { return amount; } set { amount = value; OnPropertyChanged("Amount"); } }
        public int Status { get { return status; } set { status = value; OnPropertyChanged("Status"); } }
    }
}
