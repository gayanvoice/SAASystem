using System;
using System.Collections.Generic;

namespace SAASystem.Context
{
    public interface IUserContext
    {
        UserContextModel Select(int userId);
        IEnumerable<UserContextModel> SelectAll();
        IEnumerable<UserContextModel> SelectAll(string address);
        int Insert(UserContextModel userContextModel);
        int Update(UserContextModel userContextModel);
        int Delete(int userId);
    }
}