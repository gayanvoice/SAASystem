using SAASystem.Helper;
using SAASystem.Models.Context;
using System.Collections.Generic;

namespace SAASystem.Singleton
{
    public class RoleContextSingleton
    {
        private static RoleContextSingleton instance = null;

        private const string tableName = "Role";
        private static readonly object padlock = new object();
        RoleContextSingleton()
        {
        }
        public static RoleContextSingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new RoleContextSingleton();
                    }
                    return instance;
                }
            }
        }
        public int Delete(int RoleId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(RoleId);
            string value = RoleId.ToString();
            string query = QueryHelper.GetDeleteQuery(tableName, column);
            object param = new { RoleId = value };
            return mySqlSingleton.Delete(query, param);
        }

        public int Insert(RoleContextModel roleContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetInsertQuery(tableName, roleContextModel);
            return mySqlSingleton.Insert(query, roleContextModel);
        }

        public RoleContextModel Select(int RoleId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(RoleId);
            string value = RoleId.ToString();
            string query = QueryHelper.GetSelectQuery(tableName, column);
            object param = new { RoleId = value };
            return mySqlSingleton.Select<RoleContextModel>(query, param);
        }

        public IEnumerable<RoleContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetSelectAllQuery(tableName);
            return mySqlSingleton.SelectAll<RoleContextModel>(query);
        }

        public int Update(RoleContextModel roleContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetUpdateQuery(tableName, roleContextModel);
            return mySqlSingleton.Update(query, roleContextModel);
        }
    }
}
