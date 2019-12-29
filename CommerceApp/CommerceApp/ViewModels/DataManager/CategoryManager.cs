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

        public Task<Category> GetCategoryAsync(string id)
        {
            return restService.GetObjectAsync<Category>(Constants.CategoriesUrl, id);
        }

        public Task<List<Category>> RefreshCategoryAsync(string ItemsUrl)
        {
            return restService.RefreshObjectAsync<Category>(Constants.CategoriesUrl);
        }

        public Task SaveCategoryAsync(Category item, bool isNewItem)
        {
            return restService.SaveObjectAsync<Category>(Constants.CategoriesUrl, item, isNewItem);
        }
    }
}
