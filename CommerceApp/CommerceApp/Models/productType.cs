using System;
namespace CommerceApp.Models
{
    public class productType
    {
        public int id { get; set; }
        public string full_name { get; set; }
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
        public string note { get; set; }
        public int status { get; set; }
    }
}
