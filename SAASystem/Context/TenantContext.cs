using SAASystem.Context.Interface;
using SAASystem.Helper;
using SAASystem.Models.Context;
using SAASystem.Singleton;
using System.Collections.Generic;

namespace SAASystem.Context
{
    public class TenantContext : ITenantContext
    {
        private string _tableName = "Tenant";
        public int Delete(int TenantId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(TenantId);
            string value = TenantId.ToString();
            string query = QueryHelper.GetDeleteQuery(_tableName, column);
            object param = new { TenantId = value };
            return mySqlSingleton.Delete(query, param);
        }

        public int Insert(TenantContextModel tenantContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetInsertQuery(_tableName, tenantContextModel);
            return mySqlSingleton.Insert(query, tenantContextModel);
        }

        public TenantContextModel Select(int TenantId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(TenantId);
            string value = TenantId.ToString();
            string query = QueryHelper.GetSelectQuery(_tableName, column);
            object param = new { TenantId = value};
            return mySqlSingleton.Select<TenantContextModel>(query, param);
        }

        public IEnumerable<TenantContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetSelectAllQuery(_tableName);
            return mySqlSingleton.SelectAll<TenantContextModel>(query);
        }

        public int Update(TenantContextModel tenantContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetUpdateQuery(_tableName, tenantContextModel);
            return mySqlSingleton.Update(query, tenantContextModel);
        }
    }
}
