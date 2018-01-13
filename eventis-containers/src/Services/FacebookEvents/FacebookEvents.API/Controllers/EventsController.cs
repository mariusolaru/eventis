using System;
using System.Collections.Generic;
using Business;
using Data.Domain;
using Microsoft.AspNetCore.Mvc;


namespace FacebookEvents.API.Controllers
{
    [Route("api/fbEvents")]
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
        public IEnumerable<Event> GetAllEventsUntill(DateTime dateTime)
        {
            return _repository.GetEventsUntill(dateTime);
        }

        [HttpGet("update")]
        public void GetEventsFromFacebok()
        {
            _repository.AddAllEventsFromFacebook();
        }
    }
}
