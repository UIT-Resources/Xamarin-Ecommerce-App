using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Models.Interfaces
{
    public interface ICategoryRestService
    {
        Task<List<CategoryServer>> RefreshCategoryAsync(string ItemsUrl);
        Task<CategoryServer> GetCategoryAsync(string id);
        Task SaveCategoryAsync(CategoryServer item, bool isNewItem);
        Task DeleteCategoryAsync(string id);
    }
}
