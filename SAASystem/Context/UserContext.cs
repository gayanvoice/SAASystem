using SAASystem.Helper;
using System;
using System.Collections.Generic;

namespace SAASystem.Context
{
    public class UserContext : IUserContext
    {
        private readonly IMySqlHelper _mySqlHelper;
        public UserContext(IMySqlHelper mySqlHelper)
        {
            _mySqlHelper = mySqlHelper;
        }
        public int Delete(int userId)
        {
            string query = "DELETE FROM user WHERE UserId IN (@UserId)";
            object param = new { user_id = userId };
            return _mySqlHelper.Delete(query, param);
        }
        public int Insert(UserContextModel userContextModel)
        {
            string query = "INSERT INTO user (Username, Email, PhoneNo, Surname, GivenName, Address) values " +
                "(@Username, @Email, @PhoneNo, @Surname, @GivenName, @Address)";
            return _mySqlHelper.Insert(query, userContextModel);
        }
        public UserContextModel Select(int userId)
        {
            string query = "SELECT * FROM user WHERE UserId IN (@UserId)";
            object param = new { UserId = userId };
            return _mySqlHelper.Select<UserContextModel>(query, param);
        }
        public IEnumerable<UserContextModel> SelectAll()
        {
            string query = "SELECT * FROM user";
            return _mySqlHelper.SelectAll<UserContextModel>(query);
        }
        public IEnumerable<UserContextModel> SelectAll(string address)
        {
            string query = "SELECT * FROM user WHERE address IN (@address)";
            object param = new { address = address };
            return _mySqlHelper.SelectAll<UserContextModel>(query, param);
        }
        public int Update(UserContextModel userContextModel)
        {
            string query = "UPDATE user SET Username = @Username, Email = @Email, PhoneNo = @PhoneNo, Surname = @Surname," +
                " GivenName = @GivenName, Address = @Address WHERE UserId IN (@UserId)";
            return _mySqlHelper.Update(query, userContextModel);
        }
    }
}