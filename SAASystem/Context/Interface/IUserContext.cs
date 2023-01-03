﻿using SAASystem.Models.Context;
using System.Collections.Generic;

namespace SAASystem.Context.Interface
{
    public interface IUserContext
    {
        int Delete(int userId);
        int Insert(UserContextModel userContextModel);
        UserContextModel Select(int userId);
        IEnumerable<UserContextModel> SelectAll();
        int Update(UserContextModel userContextModel);
    }
}
