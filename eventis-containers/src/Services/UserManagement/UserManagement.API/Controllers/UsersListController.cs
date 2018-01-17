using System;
using System.Collections.Generic;
using Business;
using Microsoft.AspNetCore.Mvc;
using UserManagement.API.Models;

namespace UserManagement.API.Controllers
{
    [Route("api/userslist")]
    public class UsersListController : Controller
    {
        private IUserListRepository _repository;

        public UsersListController(IUserListRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserListModel userList)
        {
            if (userList == null)
            {
                return BadRequest();
            }
            var entry = Data.Domain.UserList.Create(userList.UserEmail, userList.Location, userList.Name,
                userList.Description, userList.ImageUrl, userList.EventType , userList.StartTime, userList.EndTime);
            _repository.Add(entry);

            return CreatedAtRoute("GetById", new { Id = entry.Id }, entry);
        }

        [HttpGet("{id:Guid}", Name = "GetById")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_repository.GetById(id));
        }

        [HttpGet("todaysevents")]
        public IActionResult GetAllEventsFromToday()
        {
            return Ok(_repository.GetAllEventsFromToday());
        }
             
        [HttpPut("{id:Guid}")]
        public IActionResult Put(Guid id, [FromBody]UserListModel userList)
        {
            if (userList == null)
            {
                return BadRequest();
            }

            var entity = _repository.GetById(id);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Update(userList.UserEmail , userList.Location , userList.Name,
                userList.Description, userList.ImageUrl , userList.EventType , userList.StartTime, userList.EndTime);

            _repository.Edit(entity);

            return Ok(entity);
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            var entity = _repository.GetById(id);

            if (entity == null)
            {
                return NotFound();
            }

            _repository.Delete(id);

            return NoContent();
        }

        [HttpGet("email/{email}")]
        public IActionResult GetUserEventsByUserEmail(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                return BadRequest();
            }

            return Ok(_repository.GetUserEventsByEmail(email));
        }
    }
}