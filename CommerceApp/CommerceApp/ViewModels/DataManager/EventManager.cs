using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using CommerceApp.Config;
using CommerceApp.Models;
using CommerceApp.Models.Interfaces;

namespace CommerceApp.ViewModels.DataManager
{
    public class EventManager : IEventRestService
    {
        RestServiceGeneric restService;

        public EventManager(RestServiceGeneric restService)
        {
            this.restService = restService;
        }

        public Task DeleteEventAsync(string id)
        {
            return restService.DeleteObjectAsync(Constants.EventsUrl,id);
        }

        public Task<Event> GetEventAsync(string id)
        {
            return restService.GetObjectAsync<Event>(Constants.EventsUrl, id);
        }

        public Task<ObservableCollection<Event>> RefreshEventAsync()
        {
            return restService.RefreshObjectAsync<Event>(Constants.EventsUrl);
        }

        public Task SaveEventAsync(Event item, bool isNewItem)
        {
            return restService.SaveObjectAsync<Event>(Constants.EventsUrl, item, isNewItem);
        }
    }
}
