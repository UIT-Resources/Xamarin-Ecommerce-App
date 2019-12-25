using System;
namespace CommerceApp.Models
{
    public class Advertisement
    {
        public int id { get; set; }
        public string description { get; set; }
        public string note { get; set; }
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
        public string routerName { get; set; }
        public int id_root { get; set; }
        public int id_item { get; set; }
        public string items { get; set; }
        public string url_images { get; set; }
        public int status { get; set; }
        public int sort { get; set; }
    }
}
