using SAASystem.Context.Interface;
using SAASystem.Helper;
using SAASystem.Models.Context;
using SAASystem.Singleton;
using System.Collections.Generic;

namespace SAASystem.Context
{
    public class ContractContext : IContractContext
    {
        private string _tableName = "Contract";
        public int Delete(int ContractId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(ContractId);
            string value = ContractId.ToString();
            string query = QueryHelper.GetDeleteQuery(_tableName, column);
            object param = new { ContractId = value };
            return mySqlSingleton.Delete(query, param);
        }

        public int Insert(ContractContextModel contractContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetInsertQuery(_tableName, contractContextModel);
            return mySqlSingleton.Insert(query, contractContextModel);
        }

        public ContractContextModel Select(int ContractId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(ContractId);
            string value = ContractId.ToString();
            string query = QueryHelper.GetSelectQuery(_tableName, column);
            object param = new { ContractId = value};
            return mySqlSingleton.Select<ContractContextModel>(query, param);
        }

        public IEnumerable<ContractContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetSelectAllQuery(_tableName);
            return mySqlSingleton.SelectAll<ContractContextModel>(query);
        }

        public int Update(ContractContextModel contractContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetUpdateQuery(_tableName, contractContextModel);
            return mySqlSingleton.Update(query, contractContextModel);
        }
    }
}
