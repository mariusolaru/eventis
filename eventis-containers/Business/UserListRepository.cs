using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Data.Persistence;

namespace Business
{
    public class UserListRepository : IUserListRepository
    {
        private readonly IDatabaseService _service;

        public UserListRepository(IDatabaseService service)
        {
            _service = service;
        }

        public void Add(UserList userList)
        {
            _service.UsersList.Add(userList);
            _service.SaveChanges();
        }

        public IReadOnlyList<UserList> GetAll()
        {
            return _service.UsersList.ToList();
        }

        public UserList GetById(string id)
        {
            return _service.UsersList.FirstOrDefault(c => c.Id == id);
        }

        public void Edit(UserList userList)
        {
            _service.UsersList.Update(userList);
            _service.SaveChanges();
        }

        public void Delete(string id)
        {
            _service.UsersList.Remove(GetById(id));
            _service.SaveChanges();
        }
    }
}
