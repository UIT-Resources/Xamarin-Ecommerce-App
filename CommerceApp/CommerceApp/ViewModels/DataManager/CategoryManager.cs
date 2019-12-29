using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CommerceApp.Config;
using CommerceApp.Models;
using CommerceApp.Models.Interfaces;
using CommerceApp.ViewModels;

namespace CommerceApp.ViewModels.DataManager
{
    public class CategoryManager: ICategoryRestService
    {
        RestServiceGeneric restService;

        public CategoryManager(RestServiceGeneric restService)
        {
            this.restService = restService;
        }

        public Task DeleteCategoryAsync(string id)
        {
            return restService.DeleteObjectAsync(Constants.CategoriesUrl,id);
        }

        public Task<CategoryServer> GetCategoryAsync(string id)
        {
            return restService.GetObjectAsync<CategoryServer>(Constants.CategoriesUrl, id);
        }

        public Task<List<CategoryServer>> RefreshCategoryAsync(string ItemsUrl)
        {
            return restService.RefreshObjectAsync<CategoryServer>(Constants.CategoriesUrl);
        }

        public Task SaveCategoryAsync(CategoryServer item, bool isNewItem)
        {
            return restService.SaveObjectAsync<CategoryServer>(Constants.CategoriesUrl, item, isNewItem);
        }
    }
}
