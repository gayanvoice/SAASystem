using SAASystem.Context.Interface;
using SAASystem.Helper;
using SAASystem.Models.Context;
using SAASystem.Singleton;
using System.Collections.Generic;

namespace SAASystem.Context
{
    public class SuiteContext : ISuiteContext
    {
        private string _tableName = "Suite";
        public int Delete(int SuiteId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(SuiteId);
            string value = SuiteId.ToString();
            string query = QueryHelper.GetDeleteQuery(_tableName, column);
            object param = new { SuiteId = value };
            return mySqlSingleton.Delete(query, param);
        }

        public int Insert(SuiteContextModel suiteContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetInsertQuery(_tableName, suiteContextModel);
            return mySqlSingleton.Insert(query, suiteContextModel);
        }

        public SuiteContextModel Select(int SuiteId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(SuiteId);
            string value = SuiteId.ToString();
            string query = QueryHelper.GetSelectQuery(_tableName, column);
            object param = new { StockId = value};
            return mySqlSingleton.Select<SuiteContextModel>(query, param);
        }

        public IEnumerable<SuiteContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetSelectAllQuery(_tableName);
            return mySqlSingleton.SelectAll<SuiteContextModel>(query);
        }

        public int Update(SuiteContextModel suiteContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetUpdateQuery(_tableName, suiteContextModel);
            return mySqlSingleton.Update(query, suiteContextModel);
        }
    }
}
