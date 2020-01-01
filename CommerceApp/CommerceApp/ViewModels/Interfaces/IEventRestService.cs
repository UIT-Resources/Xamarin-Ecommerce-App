using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CommerceApp.Models.Interfaces
{
    public interface IEventRestService
    {
		Task<ObservableCollection<Event>> RefreshEventAsync();
		Task<Event> GetEventAsync(string id);
		Task SaveEventAsync(Event item, bool isNewItem);
		Task DeleteEventAsync(string id);
	}
}
