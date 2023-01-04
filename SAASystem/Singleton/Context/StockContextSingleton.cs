using SAASystem.Helper;
using SAASystem.Models.Context;
using System.Collections.Generic;

namespace SAASystem.Singleton
{
    public class StockContextSingleton
    {
        private static StockContextSingleton instance = null;

        private const string tableName = "Stock";
        private static readonly object padlock = new object();
        StockContextSingleton()
        {
        }
        public static StockContextSingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new StockContextSingleton();
                    }
                    return instance;
                }
            }
        }
        public int Delete(int StockId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(StockId);
            string value = StockId.ToString();
            string query = QueryHelper.GetDeleteQuery(tableName, column);
            object param = new { StockId = value };
            return mySqlSingleton.Delete(query, param);
        }

        public int Insert(StockContextModel stockContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetInsertQuery(tableName, stockContextModel);
            return mySqlSingleton.Insert(query, stockContextModel);
        }

        public StockContextModel Select(int StockId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(StockId);
            string value = StockId.ToString();
            string query = QueryHelper.GetSelectQuery(tableName, column);
            object param = new { StockId = value };
            return mySqlSingleton.Select<StockContextModel>(query, param);
        }

        public IEnumerable<StockContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetSelectAllQuery(tableName);
            return mySqlSingleton.SelectAll<StockContextModel>(query);
        }
        public int Update(StockContextModel stockContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetUpdateQuery(tableName, stockContextModel);
            return mySqlSingleton.Update(query, stockContextModel);
        }
    }
}
