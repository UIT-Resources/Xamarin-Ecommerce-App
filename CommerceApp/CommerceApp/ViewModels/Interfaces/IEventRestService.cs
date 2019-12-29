using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Models.Interfaces
{
    public interface IEventRestService
    {
		Task<List<Event>> RefreshEventAsync(string ItemsUrl);
		Task<Event> GetEventAsync(string id);
		Task SaveEventAsync(Event item, bool isNewItem);
		Task DeleteEventAsync(string id);
	}
}
