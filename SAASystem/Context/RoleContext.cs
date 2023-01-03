using SAASystem.Context.Interface;
using SAASystem.Helper;
using SAASystem.Models.Context;
using SAASystem.Singleton;
using System.Collections.Generic;

namespace SAASystem.Context
{
    public class RoleContext : IRoleContext
    {
        private string _tableName = "Role";
        public int Delete(int RoleId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(RoleId);
            string value = RoleId.ToString();
            string query = QueryHelper.GetDeleteQuery(_tableName, column);
            object param = new { RoleId = value };
            return mySqlSingleton.Delete(query, param);
        }

        public int Insert(RoleContextModel roleContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetInsertQuery(_tableName, roleContextModel);
            return mySqlSingleton.Insert(query, roleContextModel);
        }

        public RoleContextModel Select(int RoleId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(RoleId);
            string value = RoleId.ToString();
            string query = QueryHelper.GetSelectQuery(_tableName, column);
            object param = new { RoleId = value};
            return mySqlSingleton.Select<RoleContextModel>(query, param);
        }

        public IEnumerable<RoleContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetSelectAllQuery(_tableName);
            return mySqlSingleton.SelectAll<RoleContextModel>(query);
        }

        public int Update(RoleContextModel roleContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetUpdateQuery(_tableName, roleContextModel);
            return mySqlSingleton.Update(query, roleContextModel);
        }
    }
}
