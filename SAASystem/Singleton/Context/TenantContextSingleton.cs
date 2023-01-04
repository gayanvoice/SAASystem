using SAASystem.Helper;
using SAASystem.Models.Context;
using System.Collections.Generic;

namespace SAASystem.Singleton
{
    public class TenantContextSingleton
    {
        private static TenantContextSingleton instance = null;

        private const string tableName = "Tenant";
        private static readonly object padlock = new object();
        TenantContextSingleton()
        {
        }
        public static TenantContextSingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new TenantContextSingleton();
                    }
                    return instance;
                }
            }
        }
        public int Delete(int TenantId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(TenantId);
            string value = TenantId.ToString();
            string query = QueryHelper.GetDeleteQuery(tableName, column);
            object param = new { TenantId = value };
            return mySqlSingleton.Delete(query, param);
        }

        public int Insert(TenantContextModel tenantContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetInsertQuery(tableName, tenantContextModel);
            return mySqlSingleton.Insert(query, tenantContextModel);
        }

        public TenantContextModel Select(int TenantId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(TenantId);
            string value = TenantId.ToString();
            string query = QueryHelper.GetSelectQuery(tableName, column);
            object param = new { TenantId = value };
            return mySqlSingleton.Select<TenantContextModel>(query, param);
        }

        public IEnumerable<TenantContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetSelectAllQuery(tableName);
            return mySqlSingleton.SelectAll<TenantContextModel>(query);
        }

        public int Update(TenantContextModel tenantContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetUpdateQuery(tableName, tenantContextModel);
            return mySqlSingleton.Update(query, tenantContextModel);
        }
    }
}
