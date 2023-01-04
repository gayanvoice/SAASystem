using SAASystem.Context.Interface;
using SAASystem.Helper;
using SAASystem.Models.Context;
using SAASystem.Singleton;
using System;
using System.Collections.Generic;

namespace SAASystem.Context
{
    public class UserContext : IUserContext
    {
        private string _tableName = "User";
        public int Delete(int UserId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(UserId);
            string value = UserId.ToString();
            string query = QueryHelper.GetDeleteQuery(_tableName, column);
            object param = new { UserId = value };
            return mySqlSingleton.Delete(query, param);
        }

        public int Insert(UserContextModel userContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetInsertQuery(_tableName, userContextModel);
            return mySqlSingleton.Insert(query, userContextModel);
        }

        public UserContextModel Select(int UserId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(UserId);
            string value = UserId.ToString();
            string query = QueryHelper.GetSelectQuery(_tableName, column);
            object param = new { UserId = value};
            return mySqlSingleton.Select<UserContextModel>(query, param);
        }

        public UserContextModel Select(string Username)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(Username);
            string value = Username.ToString();
            string query = QueryHelper.GetSelectQuery(_tableName, column);
            object param = new { Username = value };
            return mySqlSingleton.Select<UserContextModel>(query, param);
        }

        public IEnumerable<UserContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetSelectAllQuery(_tableName);
            return mySqlSingleton.SelectAll<UserContextModel>(query);
        }

        public int Update(UserContextModel userContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetUpdateQuery(_tableName, userContextModel);
            return mySqlSingleton.Update(query, userContextModel);
        }
    }
}
