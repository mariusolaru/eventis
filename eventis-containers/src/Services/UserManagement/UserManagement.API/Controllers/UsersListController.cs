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
        public IEnumerable<Data.Domain.UserList> Get()
        {
            return _repository.GetAll();
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserListModel userList)
        {
            if (userList == null)
            {
                return BadRequest();
            }
            var entry = Data.Domain.UserList.Create(userList.Id , userList.UserEmail, userList.Location, userList.Name,
                userList.Description, userList.ImageUrl, userList.EventType , userList.StartTime, userList.EndTime);
            _repository.Add(entry);

            return CreatedAtRoute("GetById", new { Id = entry.Id }, entry);
        }

        [HttpGet("{id}", Name = "GetById")]
        public Data.Domain.UserList GetById(String id)
        {
            return _repository.GetById(id);
        }

        [HttpGet("todaysevents")]
        public IEnumerable<Data.Domain.UserList> GetAllEventsFromToday()
        {
            return _repository.GetAllEventsFromToday();
        }
             
        [HttpPut("{id}")]
        public void Put(String id, [FromBody]UserListModel userList)
        {
            var entity = _repository.GetById(id);
            entity.Update(userList.Id , userList.UserEmail , userList.Location , userList.Name,
                userList.Description, userList.ImageUrl , userList.EventType , userList.StartTime, userList.EndTime);

            _repository.Edit(entity);
        }

        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            _repository.Delete(id);
        }

        [HttpGet("email/{email}")]
        public IEnumerable<Data.Domain.UserList> GetUserEventsByUserEmail(string email)
        {
            return _repository.GetUserEventsByEmail(email);
        }
    }
}