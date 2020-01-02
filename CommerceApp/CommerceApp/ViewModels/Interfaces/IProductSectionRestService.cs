using CommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.ViewModels.Interfaces
{
    public interface IProductSectionRestService
    {
        Task<ObservableCollection<ProductSection>> RefreshProductSectionAsync();
        Task<ProductSection> GetProductSectionAsync(string id);
        Task SaveProductSectionAsync(ProductSection item, bool isNewItem);
        Task DeleteProductSectionAsync(string id);
    }
}