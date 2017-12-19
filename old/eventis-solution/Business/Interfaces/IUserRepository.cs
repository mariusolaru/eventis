using System;
using System.Collections.Generic;
using System.Text;
using Data.Domain;

namespace Business.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        IReadOnlyList<User> GetAllUsers();
        List<CustomEvent> GetAllEventsForAnUser(Guid id);
    }
}
