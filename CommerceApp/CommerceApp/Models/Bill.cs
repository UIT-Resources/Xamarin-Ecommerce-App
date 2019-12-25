using System;
namespace CommerceApp.Models
{
    public class Bill
    {
        public Int64 id { get; set; }
        public DateTime? create_date { get; set; }
        public DateTime? update_date { get; set; }
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
    }
}
