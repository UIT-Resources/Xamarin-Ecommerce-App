using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
//using System.ComponentModel.DataAnnotations;
namespace CommerceApp.Models
{
    public class Product
    {
        public class ItemDao
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
        public ItemDao item { get; set; }
         public Product(int idl)
        {
          item = new ItemDao();
          item.id = idl;
        }
        public async Task GetData()
        {
            
            Api api = new Api();
            try
            {
                Console.WriteLine("*********** Get data*****************");

                var result = await  api.Get("/product/select/" + item.id);
                string json = result;
                Console.WriteLine(json);
                item = JsonConvert.DeserializeObject<ItemDao>(json);
                Console.WriteLine(item.full_name);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error setid {0}", e.Message);
            }
        }

    }
}
