using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Interfaces;
using Data.Domain;
using Data.Domain.Persistence;

namespace Business
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseService _service;

        public UserRepository(IDatabaseService service)
        {
            _service = service;
        }

        public void Add(User user)
        {
            _service.Users.Add(user);
            _service.SaveChanges();
        }

        public List<CustomEvent> GetAllEventsForAnUser(Guid id)
        {
            User user = GetById(id);

            return user.CustomEvents;
        }

        public User GetById(Guid id)
        {
            return _service.Users.FirstOrDefault(c => c.Id == id);
        }

        public IReadOnlyList<User> GetAllUsers()
        {
            return _service.Users.ToList();
        }
    }
}
