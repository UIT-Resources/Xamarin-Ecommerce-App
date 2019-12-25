using System;
namespace CommerceApp.Models
{
    public class Address
    {
        public long id { get; set; }
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
        public string note { get; set; }
        public string province { get; set; }
        public string district { get; set; }
        public string ward { get; set; }
        public string detail { get; set; }
        public int status { get; set; }
        public int user_id { get; set; }
        public string full_name { get; set; }
        public string phone { get; set; }
    }
}
