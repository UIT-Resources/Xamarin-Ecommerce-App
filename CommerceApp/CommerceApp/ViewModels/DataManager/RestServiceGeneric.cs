using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using CommerceApp.Models.Interfaces;
using System.Collections.ObjectModel;

namespace CommerceApp.Models
{
    public class RestServiceGeneric : IRestServiceGeneric
    {
        HttpClient _client;

        public RestServiceGeneric()
        {
            _client = new HttpClient();
        }

        public async Task<ObservableCollection<T>> RefreshObjectAsync<T>(string ItemsUrl)
        {
            ObservableCollection<T> Items = new ObservableCollection<T>();

            var uri = new Uri(string.Format(ItemsUrl, string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<ObservableCollection<T>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }


            return Items;
        }

        public async Task<T> GetObjectAsync<T>(string ItemsUrl, string id)
        {
            T Item = default(T);
            var uri = new Uri(string.Format(ItemsUrl, id));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Item = JsonConvert.DeserializeObject<T>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Item;
        }

        public async Task SaveObjectAsync<T>(string ItemsUrl, T item, bool isNewItem)
        {
            var uri = new Uri(string.Format(ItemsUrl, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await _client.PostAsync(uri, content);
                }
                else
                {
                    response = await _client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task DeleteObjectAsync(string ItemsUrl, string id)
        {
            var uri = new Uri(string.Format(ItemsUrl, id));

            try
            {
                var response = await _client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tItem successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
    }
}
