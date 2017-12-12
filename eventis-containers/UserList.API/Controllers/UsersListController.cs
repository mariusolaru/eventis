using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Mvc;
using UserList.API.Models;

namespace UserList.API.Controllers
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
        public IEnumerable<Data.UserList> Get()
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
            var entry = Data.UserList.Create(userList.UserId , userList.Location, userList.Id, userList.FacebookId, userList.Name, 
                                        userList.Description, userList.StartTime, userList.EndTime, userList.ImageURL);
            _repository.Add(entry);

            return CreatedAtRoute("GetById", new { id = entry.Id }, entry);
        }

        [HttpGet("{id}", Name = "GetById")]
        public Data.UserList Get(String id)
        {
            return _repository.GetById(id);
        }

        [HttpPut("{id}")]
        public void Put(String id, [FromBody]UserListModel userList)
        {
            var entity = _repository.GetById(id);
            entity.Update(userList.UserId ,userList.Location, userList.Id, userList.FacebookId, userList.Name,
                          userList.Description, userList.StartTime, userList.EndTime, userList.ImageURL);

            _repository.Edit(entity);
        }

        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            _repository.Delete(id);
        }
    }
}
