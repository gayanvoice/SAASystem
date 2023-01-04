using SAASystem.Helper;
using SAASystem.Models.Context;
using System.Collections.Generic;

namespace SAASystem.Singleton
{
    public class UserContextSingleton
    {
        private static UserContextSingleton instance = null;

        private const string tableName = "User";
        private static readonly object padlock = new object();
        UserContextSingleton()
        {
        }
        public static UserContextSingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new UserContextSingleton();
                    }
                    return instance;
                }
            }
        }
        public int Delete(int UserId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(UserId);
            string value = UserId.ToString();
            string query = QueryHelper.GetDeleteQuery(tableName, column);
            object param = new { UserId = value };
            return mySqlSingleton.Delete(query, param);
        }
        public int Insert(UserContextModel userContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetInsertQuery(tableName, userContextModel);
            return mySqlSingleton.Insert(query, userContextModel);
        }
        public UserContextModel Select(int UserId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(UserId);
            string value = UserId.ToString();
            string query = QueryHelper.GetSelectQuery(tableName, column);
            object param = new { UserId = value };
            return mySqlSingleton.Select<UserContextModel>(query, param);
        }
        public UserContextModel Select(string Username)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(Username);
            string value = Username.ToString();
            string query = QueryHelper.GetSelectQuery(tableName, column);
            object param = new { Username = value };
            return mySqlSingleton.Select<UserContextModel>(query, param);
        }
        public IEnumerable<UserContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetSelectAllQuery(tableName);
            return mySqlSingleton.SelectAll<UserContextModel>(query);
        }
        public int Update(UserContextModel userContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetUpdateQuery(tableName, userContextModel);
            return mySqlSingleton.Update(query, userContextModel);
        }
    }
}