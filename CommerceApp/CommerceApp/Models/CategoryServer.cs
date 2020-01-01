using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceApp.Models
{
    public class CategoryServer
    {
        public int id { get; set; }
        public string full_name { get; set; }
        public DateTime? create_date { get; set; }
        public DateTime? update_date { get; set; }
        public string note { get; set; }
        public int status { get; set; }
        public string url_images;
    }
}
