using SAASystem.Context.Interface;
using SAASystem.Helper;
using SAASystem.Models.Context;
using SAASystem.Singleton;
using System.Collections.Generic;

namespace SAASystem.Context
{
    public class EmployeeContext : IEmployeeContext
    {
        private string _tableName = "Employee";
        public int Delete(int EmployeeId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(EmployeeId);
            string value = EmployeeId.ToString();
            string query = QueryHelper.GetDeleteQuery(_tableName, column);
            object param = new { EmployeeId = value };
            return mySqlSingleton.Delete(query, param);
        }

        public int Insert(EmployeeContextModel employeeContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetInsertQuery(_tableName, employeeContextModel);
            return mySqlSingleton.Insert(query, employeeContextModel);
        }

        public EmployeeContextModel Select(int EmployeeId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(EmployeeId);
            string value = EmployeeId.ToString();
            string query = QueryHelper.GetSelectQuery(_tableName, column);
            object param = new { EmployeeId = value};
            return mySqlSingleton.Select<EmployeeContextModel>(query, param);
        }

        public IEnumerable<EmployeeContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetSelectAllQuery(_tableName);
            return mySqlSingleton.SelectAll<EmployeeContextModel>(query);
        }

        public int Update(EmployeeContextModel employeeContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetUpdateQuery(_tableName, employeeContextModel);
            return mySqlSingleton.Update(query, employeeContextModel);
        }
    }
}
