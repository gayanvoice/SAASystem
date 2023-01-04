using SAASystem.Helper;
using SAASystem.Models.Context;
using System.Collections.Generic;

namespace SAASystem.Singleton
{
    public class EmployeeContextSingleton
    {
        private static EmployeeContextSingleton instance = null;

        private const string tableName = "Employee";
        private static readonly object padlock = new object();
        EmployeeContextSingleton()
        {
        }
        public static EmployeeContextSingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new EmployeeContextSingleton();
                    }
                    return instance;
                }
            }
        }
        public int Delete(int EmployeeId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(EmployeeId);
            string value = EmployeeId.ToString();
            string query = QueryHelper.GetDeleteQuery(tableName, column);
            object param = new { EmployeeId = value };
            return mySqlSingleton.Delete(query, param);
        }

        public int Insert(EmployeeContextModel employeeContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetInsertQuery(tableName, employeeContextModel);
            return mySqlSingleton.Insert(query, employeeContextModel);
        }

        public EmployeeContextModel Select(int EmployeeId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(EmployeeId);
            string value = EmployeeId.ToString();
            string query = QueryHelper.GetSelectQuery(tableName, column);
            object param = new { EmployeeId = value };
            return mySqlSingleton.Select<EmployeeContextModel>(query, param);
        }

        public IEnumerable<EmployeeContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetSelectAllQuery(tableName);
            return mySqlSingleton.SelectAll<EmployeeContextModel>(query);
        }

        public int Update(EmployeeContextModel employeeContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetUpdateQuery(tableName, employeeContextModel);
            return mySqlSingleton.Update(query, employeeContextModel);
        }
    }
}
