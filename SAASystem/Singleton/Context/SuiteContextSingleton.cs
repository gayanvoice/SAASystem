using SAASystem.Helper;
using SAASystem.Models.Context;
using System.Collections.Generic;

namespace SAASystem.Singleton
{
    public class SuiteContextSingleton
    {
        private static SuiteContextSingleton instance = null;

        private const string tableName = "Suite";
        private static readonly object padlock = new object();
        SuiteContextSingleton()
        {
        }
        public static SuiteContextSingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SuiteContextSingleton();
                    }
                    return instance;
                }
            }
        }
        public int Delete(int SuiteId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(SuiteId);
            string value = SuiteId.ToString();
            string query = QueryHelper.GetDeleteQuery(tableName, column);
            object param = new { SuiteId = value };
            return mySqlSingleton.Delete(query, param);
        }

        public int Insert(SuiteContextModel suiteContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetInsertQuery(tableName, suiteContextModel);
            return mySqlSingleton.Insert(query, suiteContextModel);
        }

        public SuiteContextModel Select(int SuiteId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(SuiteId);
            string value = SuiteId.ToString();
            string query = QueryHelper.GetSelectQuery(tableName, column);
            object param = new { SuiteId = value };
            return mySqlSingleton.Select<SuiteContextModel>(query, param);
        }

        public IEnumerable<SuiteContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetSelectAllQuery(tableName);
            return mySqlSingleton.SelectAll<SuiteContextModel>(query);
        }

        public int Update(SuiteContextModel suiteContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetUpdateQuery(tableName, suiteContextModel);
            return mySqlSingleton.Update(query, suiteContextModel);
        }
    }
}
