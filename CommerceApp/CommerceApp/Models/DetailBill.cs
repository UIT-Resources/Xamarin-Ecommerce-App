using System;
namespace CommerceApp.Models
{
    public class DetailBill
    {
        public Int64 id { get; set; }
        public DateTime? create_date { get; set; }
        public DateTime? update_date { get; set; }
        public string note { get; set; }
        public int id_item { get; set; }
        public long id_bill { get; set; }
        public double total_money { get; set; }
        public int status { get; set; }
        public double amount { get; set; }
        public double actual_export { get; set; }
    }
}
