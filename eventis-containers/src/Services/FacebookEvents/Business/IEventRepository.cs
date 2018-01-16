using System;
using System.Collections.Generic;
using Data.Domain;

namespace Business
{
    public interface IEventRepository
    {
        List<Event> GetAllActiveEvents();

        void AddEvent(Event _event);

        void DeleteEvent(Event ev);

        void AddAllEventsFromFacebook();

        List<Event> GetEventsUntill(DateTime dateTime);

        PagedList<Event> GetEvents(PagingParams pagingParams);

        Event GetEventById(Guid id);

    }
}
