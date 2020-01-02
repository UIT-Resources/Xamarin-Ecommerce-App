using CommerceApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Linq;
using CommerceApp.ViewModels.Interfaces;

namespace CommerceApp.ViewModels.DataManager
{
    public class ProductSectionRestServiceGeneric:RestServiceGeneric
    {
        public ProductSectionRestServiceGeneric():base()
        {
        }

        public override async Task<ObservableCollection<T>> RefreshObjectAsync<T>(string ItemsUrl)
        {
            Console.WriteLine("RefreshObjectAsync is running");
            ObservableCollection<T> Items = new ObservableCollection<T>();

            var uri = new Uri(string.Format(ItemsUrl, string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    JObject results = JObject.Parse(content);
                    // get JSON result objects into a list
                    IList<JToken> productSections = results["items"].Children().ToList();
                    IList<ProductSection> ProductSections = new ObservableCollection<ProductSection>();
                    foreach (JToken result in productSections)
                    {
                        // JToken.ToObject is a helper method that uses JsonSerializer internally
                        JToken category = result["root"];
                        JToken product = result["element"];
                        ProductSection productSection = new ProductSection();
                        productSection.category = category.ToObject<Category>();
                        productSection.products = product.ToObject<ObservableCollection<Product>>();
                        //Console.WriteLine($"Category: {JsonConvert.SerializeObject(productSection.category)}");
                        //Console.WriteLine($"Product: {JsonConvert.SerializeObject(productSection.products)}");
                        ProductSections.Add(productSection);
                    };
                    //Items = JsonConvert.DeserializeObject<ObservableCollection<T>>(content);
                    Items = (ObservableCollection<T>)ProductSections;
                    Console.WriteLine("==>>RefreshObjectAsync successfully runned");
                    Console.WriteLine($"+ Data includes {Items.Count} elements");

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }
    }
}
