using System;
using System.Collections.Generic;

namespace SAASystem.Helper
{
    public interface IUserContext
    {
        UserModel Select(int userId);
        IEnumerable<UserModel> SelectAll();
        IEnumerable<UserModel> SelectAll(string address);
        int Insert(string username, string email, string phoneNo, string surname, string givenName, string address, DateTime lastLogin);
        int Update(int userId, string username);
        int Delete(int userId);
    }
}