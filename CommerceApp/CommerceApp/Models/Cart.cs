using System;
namespace CommerceApp.Models
{
    public class Cart
    {

        public Int64 id { get; set; }
        public int user_id { get; set; }
        public int item_id { get; set; }
        public DateTime create_date { get; set; }
        public int amount { get; set; }
        public int status { get; set; }
    }
}
