using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Models.Interfaces
{
    public interface IRestServiceGeneric
    {
			//Get List Items Type T
			Task<List<T>> RefreshObjectAsync<T>(string ItemsUrl);
			//Get Item Type T Which has ID = id
			Task<T> GetObjectAsync<T>(string ItemsUrl, string id);
			//Save Item Type T. If It's already exist then Update else Create
			Task SaveObjectAsync<T>(string ItemsUrl, T item, bool isNewItem);
		    //Delete Item Type T.
			Task DeleteObjectAsync(string ItemsUrl,string id);
	}
}
