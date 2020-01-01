using System;
namespace CommerceApp.Models
{
    public class Description
    {
        public long id { get; set; }
        public DateTime? create_date { get; set; }
        public DateTime? update_date { get; set; }
        public string context { get; set; }
        public int create_by { get; set; }
        public int id_item { get; set; }
        public int index { get; set; }
        public int status { get; set; }
        //khoa
    }
}
