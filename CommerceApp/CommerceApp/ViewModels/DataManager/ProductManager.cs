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

        public Task<ProductServer> GetProductAsync(string id)
        {
            return restService.GetObjectAsync<ProductServer>(Constants.ProductsUrl, id);
        }

        public Task<List<ProductServer>> RefreshProductAsync()
        {
            return restService.RefreshObjectAsync<ProductServer>(Constants.ProductsUrl);
        }

        public Task SaveProductAsync(ProductServer item, bool isNewItem)
        {
            return restService.SaveObjectAsync<ProductServer>(Constants.ProductsUrl, item, isNewItem);
        }
    }
}
