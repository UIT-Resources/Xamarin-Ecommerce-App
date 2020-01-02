using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceApp.Models
{
    class BillOfUser : BindableBase
    {
        public int id { get; set; }
        public string create_date { get; set; }
        public string update_date { get; set; }
        public string note { get; set; }
        public string create_by { get; set; }
        public int amount_item { get; set; }
        public int user_id { get; set; }
        public double total { get; set; }
        public int status { get; set; }
        public double guest_money { get; set; }
        public double money_back { get; set; }
        public string receiver { get; set; }
        public string phone_receiver { get; set; }
        public int id_address { get; set; }

        public int Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
        public string Create_date { get { return create_date; } set { create_date = value; OnPropertyChanged("Create_date"); } }
        public string Update_date { get { return update_date; } set { update_date = value; OnPropertyChanged("Update_date"); } }
        public string Note { get { return note; } set { note = value; OnPropertyChanged("Note"); } }
        public string Create_by { get { return create_by; } set { create_by = value; OnPropertyChanged("Create_by"); } }
        public int Amount_item { get { return amount_item; } set { amount_item = value; OnPropertyChanged("Amount_item"); } }
        public int User_id { get { return user_id; } set { user_id = value; OnPropertyChanged("User_id"); } }
        public double Total { get { return total; } set { total = value; OnPropertyChanged("Total"); } }
        public int Status { get { return status; } set { status = value; OnPropertyChanged("Status"); } }
        public double Guest_money { get { return guest_money; } set { guest_money = value; OnPropertyChanged("Guest_money"); } }
        public double Money_back { get { return money_back; } set { money_back = value; OnPropertyChanged("Money_back"); } }
        public string Receiver { get { return receiver; } set { receiver = value; OnPropertyChanged("Receiver"); } }
        public string Phone_receiver { get { return phone_receiver; } set { phone_receiver = value; OnPropertyChanged("Phone_receiver"); } }
        public int Id_address { get { return id_address; } set { id_address = value; OnPropertyChanged("Id_address"); } }



    }
}
