using SAASystem.Context.Interface;
using SAASystem.Helper;
using SAASystem.Models.Context;
using SAASystem.Singleton;
using System.Collections.Generic;

namespace SAASystem.Context
{
    public class StockContext : IStockContext
    {
        private string _tableName = "Stock";
        public int Delete(int StockId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(StockId);
            string value = StockId.ToString();
            string query = QueryHelper.GetDeleteQuery(_tableName, column);
            object param = new { StockId = value };
            return mySqlSingleton.Delete(query, param);
        }

        public int Insert(StockContextModel stockContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetInsertQuery(_tableName, stockContextModel);
            return mySqlSingleton.Insert(query, stockContextModel);
        }

        public StockContextModel Select(int StockId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(StockId);
            string value = StockId.ToString();
            string query = QueryHelper.GetSelectQuery(_tableName, column);
            object param = new { StockId = value};
            return mySqlSingleton.Select<StockContextModel>(query, param);
        }

        public IEnumerable<StockContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetSelectAllQuery(_tableName);
            return mySqlSingleton.SelectAll<StockContextModel>(query);
        }

        public int Update(StockContextModel stockContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetUpdateQuery(_tableName, stockContextModel);
            return mySqlSingleton.Update(query, stockContextModel);
        }
    }
}
