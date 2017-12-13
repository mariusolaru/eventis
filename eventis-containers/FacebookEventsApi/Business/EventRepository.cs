using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Domain;
using Data.Persistence;
using FacebookCrawler;

namespace Business
{
    public class EventRepository : IEventRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public EventRepository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public List<Event> GetAllActiveEvents()
        {
            return _databaseContext.Events.Where(e => e.StartTime > DateTime.Now).ToList();
        }

        public void AddEvent(Event _event)
        {
            _databaseContext.Events.Add(_event);
            _databaseContext.SaveChanges();
        }

        public void DeleteEvent(Event ev)
        {
            _databaseContext.Events.Remove(ev);
            _databaseContext.SaveChanges();
        }

        public void AddAllEventsFromFacebook()
        {
            var facebookClient = new FacebookClient();

            var getLocationsTask = facebookClient.GetLocations(FacebookSettings.AccessToken);

            //remove all existing events from database

            var exEvents = GetAllActiveEvents();

            foreach (var ev in exEvents)
            {
                DeleteEvent(ev);       
            }
            
            //wait for locations task to finish

            Task.WaitAll(getLocationsTask);
            var locations = getLocationsTask.Result;

            //get all events from facebook 

            var getEventsTask = facebookClient.GetEvents(FacebookSettings.AccessToken, locations);
            //wait for event task to finish
            Task.WaitAll(getEventsTask);

            var events = getEventsTask.Result;
            //add events to database
            foreach (var ev in events)
            {
                var eventStartTime = DateTime.Parse(ev.StartTime, null, System.Globalization.DateTimeStyles.RoundtripKind);

                DateTime eventEndTime;
                if (String.IsNullOrEmpty(ev.EndTime))
                {
                    eventEndTime = eventStartTime.AddHours(3);
                }
                else
                {
                    eventEndTime = DateTime.Parse(ev.EndTime, null, System.Globalization.DateTimeStyles.RoundtripKind);
                }
                var newEvent = Event.Create(ev.Place, ev.FacebookId, ev.Name, ev.Description, eventStartTime, eventEndTime,
                    ev.Cover.Source);
                AddEvent(newEvent);
            }

            _databaseContext.SaveChanges();

        }

        public List<Event> GetEventsUntill(DateTime dateTime)
        {
            return _databaseContext.Events.Where(e => e.StartTime <= dateTime).ToList();
        }
    }
}
