using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Models.Interfaces
{
    public interface ICategoryRestService
    {
        Task<List<Category>> RefreshCategoryAsync(string ItemsUrl);
        Task<Category> GetCategoryAsync(string id);
        Task SaveCategoryAsync(Category item, bool isNewItem);
        Task DeleteCategoryAsync(string id);
    }
}
