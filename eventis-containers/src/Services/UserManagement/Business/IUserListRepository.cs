using System;
using System.Collections.Generic;
using Data.Domain;

namespace Business
{
    public interface IUserListRepository
    {
        void Add(UserList userList);
        IReadOnlyList<UserList> GetAll();
        IReadOnlyList<UserList> GetAllEventsFromToday();
        UserList GetById(Guid id);
        void Edit(UserList userList);
        void Delete(Guid id);
        IReadOnlyList<UserList> GetUserEventsByEmail(string userEmail);
    }
}
