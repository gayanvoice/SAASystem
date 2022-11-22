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
            string query = "DELETE FROM user WHERE user_id IN (@user_id)";
            object param = new { user_id = userId };
            return _mySqlHelper.Delete(query, param);
        }
        public int Insert(string username, string email, string phoneNo,
            string surname, string givenName, string address, DateTime lastLogin)
        {
            string query = "INSERT INTO user (username, email, phone_no, surname, given_name, address, last_login)" +
                " values (@username, @email, @phone_no, @surname, @given_name, @address, @last_login)";
            object param = new
            {
                username = username,
                email = email,
                phone_no = phoneNo,
                surname = surname,
                given_name = givenName,
                address = address,
                last_login = _mySqlHelper.ConvertDateTimeToString(lastLogin)
            };
            return _mySqlHelper.Insert(query, param);
        }
        public UserModel Select(int userId)
        {
            string query = "SELECT user_id UserId, username Username, email Email, phone_no PhoneNo, surname Surname," +
                " given_name GivenName, address Address, last_login LastLogin FROM user WHERE user_id IN (@user_id)";
            object param = new { user_id = userId };
            return _mySqlHelper.Select<UserModel>(query, param);
        }
        public IEnumerable<UserModel> SelectAll()
        {
            string query = "SELECT user_id UserId, username Username, email Email, phone_no PhoneNo, surname Surname," +
               " given_name GivenName, address Address, last_login LastLogin FROM user";
            return _mySqlHelper.SelectAll<UserModel>(query);
        }
        public IEnumerable<UserModel> SelectAll(string address)
        {
            string query = "SELECT user_id UserId, username Username, email Email, phone_no PhoneNo, surname Surname," +
              " given_name GivenName, address Address, last_login LastLogin FROM user WHERE address IN (@address)";
            object param = new { address = address };
            return _mySqlHelper.SelectAll<UserModel>(query, param);
        }
        public int Update(int userId, string username, string email, string phoneNo, string surname, string givenName, string address)
        {
            string query = "UPDATE user SET username = @username, email = @email, phone_no = @phone_no, surname = @surname, " +
                "given_name = @given_name, address = @address WHERE user_id IN (@user_id)";
            object param = new 
            {
                user_id = userId,
                username = username,
                email = email,
                phone_no = phoneNo,
                surname = surname,
                given_name = givenName,
                address = address
            };
            return _mySqlHelper.Update(query, param);
        }
    }
}