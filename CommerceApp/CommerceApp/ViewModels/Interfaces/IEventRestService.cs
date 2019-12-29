using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Models.Interfaces
{
    public interface IEventRestService
    {
		Task<List<EventServer>> RefreshEventAsync(string ItemsUrl);
		Task<EventServer> GetEventAsync(string id);
		Task SaveEventAsync(EventServer item, bool isNewItem);
		Task DeleteEventAsync(string id);
	}
}
