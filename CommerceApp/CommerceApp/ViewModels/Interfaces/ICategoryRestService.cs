using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Models.Interfaces
{
    public interface ICategoryRestService
    {
        Task<ObservableCollection<Category>> RefreshCategoryAsync();
        Task<Category> GetCategoryAsync(string id);
        Task SaveCategoryAsync(Category item, bool isNewItem);
        Task DeleteCategoryAsync(string id);
    }
}
