using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceApp.Models
{
    public class Images
    {
        public int id { get; set; }
        public int id_item { get; set; }
        public int create_by { get; set; }
        public int index { get; set; }
        public DateTime? create_date { get; set; }
        public DateTime? update_date { get; set; }
        public int status { get; set; }
        public string name { get; set; }
        private string source; 
        public string url { get { return source; } set { source = "http://uit-api-xamarin.azurewebsites.net/product/images/"+id_item+"/"+ value; } }
        //{ get; set; }{
        //khoa
    }
}
