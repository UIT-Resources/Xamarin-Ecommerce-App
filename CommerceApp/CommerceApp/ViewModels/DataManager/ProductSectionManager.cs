using CommerceApp.Models;
using CommerceApp.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using CommerceApp.Config;

namespace CommerceApp.ViewModels.DataManager
{
    public class ProductSectionManager :  IProductSectionRestService
    {
        ProductSectionRestServiceGeneric restService;

        public ProductSectionManager(ProductSectionRestServiceGeneric restService)
        {
            this.restService = restService;
        }

        public Task DeleteProductSectionAsync(string id)
        {
            return restService.DeleteObjectAsync(Constants.ProductSectionsUrl, id);
        }

        public Task<ProductSection> GetProductSectionAsync(string id)
        {
            return restService.GetObjectAsync<ProductSection>(Constants.ProductSectionsUrl, id);
        }

        public Task<ObservableCollection<ProductSection>> RefreshProductSectionAsync()
        {
            Console.WriteLine("RefreshProductSectionAsync is running");
            return restService.RefreshObjectAsync<ProductSection>(Constants.ProductSectionsUrl);
        }

        public Task SaveProductSectionAsync(ProductSection item, bool isNewItem)
        {
            return restService.SaveObjectAsync<ProductSection>(Constants.ProductSectionsUrl, item, isNewItem);
        }
    }
}
