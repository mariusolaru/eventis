using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using Data.Domain;
using Microsoft.AspNetCore.Mvc;
using UserEventsList.API.Models;

namespace UserEventsList.API.Controllers
{
    [Route("api/eventslist")]
    public class EventsListController : Controller
    {
        private IUserRepository _repository;

        public EventsListController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserModel user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            var entry = Data.Domain.User.Create(user.Name, user.Password , user.CustomEvents);
            _repository.Add(entry);
            return Ok(entry);
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _repository.GetAllUsers();
        }

        [HttpGet("{id}")]
        public IEnumerable<CustomEvent> GetAllEventsForAnUser(Guid id)
        {
            return _repository.GetAllEventsForAnUser(id);
        }

    }
}
