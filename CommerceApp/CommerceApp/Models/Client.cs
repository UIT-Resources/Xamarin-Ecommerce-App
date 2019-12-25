using System;
using System.Threading.Tasks;
using CommerceApp.Models;
using Newtonsoft.Json;

namespace CommerceApp.Models
{
    public class Client
    {
        public Client()
        {
        }
        public async Task<User> Login(string username,string password)
        {
            Api api = new Api();
            try
            {
                Console.WriteLine("*********** Get data*****************");

                var result = await api.Post("/user/login", "{username : "+ username+ ", password : "+ password+"}");
                string json = result;
                Console.WriteLine(json);
                User user = JsonConvert.DeserializeObject<User>(json);
                Console.WriteLine(user.full_name);
                return user;
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
    public class User
    {
        public int id { get; set; }
        public string full_name { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public double point { get; set; }
        public DateTime birthday { get; set; }
        public DateTime create_date { get; set; }
        public DateTime update_date { get; set; }
        public string note { get; set; }
    }
}
