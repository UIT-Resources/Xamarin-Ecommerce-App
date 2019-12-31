using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;



namespace CommerceApp.Models
{
    public class RestApi
    {
        private readonly HttpClient client;
        private readonly string domain = "http://uit-api-xamarin.azurewebsites.net";
        public RestApi()
        {
            client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            client.BaseAddress = new Uri(domain);

        }

        public async Task<string> Get(string url)

        {

            string JsonString = "";

            Uri link = new Uri(domain + url);

            try

            {
                //khoa


                var responseBody = await client.GetAsync(link);

                JsonString = await responseBody.Content.ReadAsStringAsync();

                Console.WriteLine(JsonString);

                return JsonString;

            }

            catch (HttpRequestException e)

            {

                Console.WriteLine("Error request {0}", link);

                Console.WriteLine(e.Message);

                return JsonString;



            }

        }

        public async Task<string> Post(string url, string data)

        {

            string JsonString = "";

            Uri link = new Uri(domain + url);

            try

            {

                //string jsonData = @"{""username"" : ""myusername"", ""password"" : ""mypassword""}";


                if(data==null)
                {
                     HttpResponseMessage response = await client.PostAsync(link,null);
                    string result = await response.Content.ReadAsStringAsync();

                    return result;
                }
                else
                {
                    var content = new StringContent(data, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(link, content);
                    string result = await response.Content.ReadAsStringAsync();

                return result;
                }
                



                // this result string should be something like: "{"token":"rgh2ghgdsfds"}"

               

            }

            catch (HttpRequestException e)

            {

                Console.WriteLine("Error request {0}", link);

                Console.WriteLine(e.Message);

                return JsonString;



            }

        }

    }

}