using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace Business
{
    public interface IUserListRepository
    {
        void Add(UserList userList);
        IReadOnlyList<UserList> GetAll();
        UserList GetById(String id);
        void Edit(UserList userList);
        void Delete(String id);
    }
}
