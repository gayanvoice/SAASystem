﻿using SAASystem.Models.Context;
using System.Collections.Generic;

namespace SAASystem.Context
{
    public interface IUserContext
    {
        UserContextModel Select(int userId);
        UserContextModel Select(string username);
        IEnumerable<UserContextModel> SelectAll();
        IEnumerable<UserContextModel> SelectAll(string address);
        int Insert(UserContextModel userContextModel);
        int Update(UserContextModel userContextModel);
        int Delete(int userId);
    }
}