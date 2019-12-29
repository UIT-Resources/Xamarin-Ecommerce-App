using System;
using System.Collections.Generic;
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
            return restService.DeleteObjectAsync(Constants.EventsUrl, id);
        }

        public Task<EventServer> GetEventAsync(string id)
        {
            return restService.GetObjectAsync<EventServer>(Constants.EventsUrl, id);
        }

        public Task<List<EventServer>> RefreshEventAsync(string ItemsUrl)
        {
            return restService.RefreshObjectAsync<EventServer>(Constants.EventsUrl);
        }

        public Task SaveEventAsync(EventServer item, bool isNewItem)
        {
            return restService.SaveObjectAsync<EventServer>(Constants.EventsUrl, item, isNewItem);
        }
    }
}
