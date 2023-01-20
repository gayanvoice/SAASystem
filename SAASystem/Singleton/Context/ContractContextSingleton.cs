using SAASystem.Helper;
using SAASystem.Models.Context;
using System.Collections.Generic;

namespace SAASystem.Singleton
{
    public class ContractContextSingleton
    {
        private static ContractContextSingleton instance = null;

        private const string tableName = "Contract";
        private static readonly object padlock = new object();
        ContractContextSingleton()
        {
        }
        public static ContractContextSingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ContractContextSingleton();
                    }
                    return instance;
                }
            }
        }
        public int Delete(int ContractId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(ContractId);
            string value = ContractId.ToString();
            string query = QueryHelper.GetDeleteQuery(tableName, column);
            object param = new { ContractId = value };
            return mySqlSingleton.Delete(query, param);
        }

        public int Insert(ContractContextModel contractContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetInsertQuery(tableName, contractContextModel);
            return mySqlSingleton.Insert(query, contractContextModel);
        }

        public ContractContextModel Select(int ContractId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(ContractId);
            string value = ContractId.ToString();
            string query = QueryHelper.GetSelectQuery(tableName, column);
            object param = new { ContractId = value };
            return mySqlSingleton.Select<ContractContextModel>(query, param);
        }

        public ContractContextModel SelectByUserId(int UserId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(UserId);
            string value = UserId.ToString();
            string query = QueryHelper.GetSelectQuery(tableName, column);
            object param = new { UserId = value };
            return mySqlSingleton.Select<ContractContextModel>(query, param);
        }

        public IEnumerable<ContractContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetSelectAllQuery(tableName);
            return mySqlSingleton.SelectAll<ContractContextModel>(query);
        }

        public int Update(ContractContextModel contractContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetUpdateQuery(tableName, contractContextModel);
            return mySqlSingleton.Update(query, contractContextModel);
        }
    }
}
