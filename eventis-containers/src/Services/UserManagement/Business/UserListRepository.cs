using System;
using System.Collections.Generic;
using System.Linq;
using Data.Domain;
using Data.Persistence;

namespace Business
{
    public class UserListRepository : IUserListRepository
    {
        private readonly IDatabaseContext _service;

        public UserListRepository(IDatabaseContext service)
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

        public UserList GetById(string facebookId)
        {
            return _service.UsersList.FirstOrDefault(c => c.Id == facebookId);
        }

        public IReadOnlyList<UserList> GetAllEventsFromToday()
        {
            return _service.UsersList.Where(c => c.StartTime.Date == DateTime.Today.Date).ToList();
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

        public IReadOnlyList<UserList> GetUserEventsByEmail(string userEmail)
        {
            return _service.UsersList.Where(e => e.UserEmail.Equals(userEmail)).ToList();
        }
    }
}
