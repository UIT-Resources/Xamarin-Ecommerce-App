using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CommerceApp.Models;
using CommerceApp.Models.Interfaces;
using CommerceApp.Config;

namespace CommerceApp.ViewModels.DataManager
{
    public class ProductManager : IProductRestService
    {
        RestServiceGeneric restService;

        public ProductManager(RestServiceGeneric service)
        {
            restService = service;
        }

        public Task DeleteProductAsync(string id)
        {
            return restService.DeleteObjectAsync(Constants.ProductsUrl, id);
        }

        public Task<Product> GetProductAsync(string id)
        {
            return restService.GetObjectAsync<Product>(Constants.ProductsUrl, id);
        }

        public Task<List<Product>> RefreshProductAsync()
        {
            return restService.RefreshObjectAsync<Product>(Constants.ProductsUrl);
        }

        public Task SaveProductAsync(Product item, bool isNewItem)
        {
            return restService.SaveObjectAsync<Product>(Constants.ProductsUrl, item, isNewItem);
        }
    }
}
