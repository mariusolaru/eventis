using System;
using System.Collections.Generic;
using Business;
using Data.Domain;
using Microsoft.AspNetCore.Mvc;


namespace EventsApi.Controllers
{
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private readonly IEventRepository _repository;

        public EventsController(IEventRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<Event> GetAllActiveEvents()
        {
            return _repository.GetAllActiveEvents();
        }

        [HttpGet("{dateTime}")]
        public IEnumerable<Event> GetAllEventsUntill(Int64 dateTime)
        {
            return _repository.GetEventsUntill(new DateTime(dateTime));
        }
    }
}
