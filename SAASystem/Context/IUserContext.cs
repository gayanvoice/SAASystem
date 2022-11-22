using System;
using System.Collections.Generic;

namespace SAASystem.Context
{
    public interface IUserContext
    {
        UserModel Select(int userId);
        IEnumerable<UserModel> SelectAll();
        IEnumerable<UserModel> SelectAll(string address);
        int Insert(string username, string email, string phoneNo, string surname, string givenName, string address, DateTime lastLogin);
        int Update(int userId, string username, string email, string phoneNo, string surname, string givenName, string address);
        int Delete(int userId);
    }
}