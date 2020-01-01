using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Models.Interfaces
{
    public interface IProductRestService
    {
		//Get List Products
		Task<ObservableCollection<Product>> RefreshProductAsync();
		//Get Product Which has ID = id
		Task<Product> GetProductAsync(string id);
		//Save Product. If It's already exist then Update else Create
		Task SaveProductAsync(Product item, bool isNewItem);
		//Delete Product.
		Task DeleteProductAsync(string id);
	}
}
