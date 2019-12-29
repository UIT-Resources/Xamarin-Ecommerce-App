using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceApp.Models
{
    public class Product : BindableBase
    {
        public int id { get; set; }
        public string full_name { get; set; }
        public DateTime? create_date { get; set; }
        public DateTime? update_date { get; set; }
        public string note { get; set; }
        public int root_id { get; set; }
        public double cost { get; set; }
        public string unit { get; set; }

        public string url_images { get; set; }
        public int status { get; set; }
        public double rank { get; set; }
        public string origin { get; set; }
        public string trademark { get; set; } 
        public DateTime? dateofmanufacture { get; set; }
        public DateTime? expirationdate { get; set; }
        public string description { get; set; }
     
    }
}
