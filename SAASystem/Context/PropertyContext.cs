using SAASystem.Context.Interface;
using SAASystem.Helper;
using SAASystem.Models.Context;
using SAASystem.Singleton;
using System;
using System.Collections.Generic;

namespace SAASystem.Context
{
    public class PropertyContext : IPropertyContext
    {
        private string _tableName = "Property";
        public int Delete(int PropertyId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(PropertyId);
            string value = PropertyId.ToString();
            string query = QueryHelper.GetDeleteQuery(_tableName, column);
            object param = new { PropertyId = value };
            return mySqlSingleton.Delete(query, param);
        }

        public int Insert(PropertyContextModel propertyContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetInsertQuery(_tableName, propertyContextModel);
            return mySqlSingleton.Insert(query, propertyContextModel);
        }

        public PropertyContextModel Select(int PropertyId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(PropertyId);
            string value = PropertyId.ToString();
            string query = QueryHelper.GetSelectQuery(_tableName, column);
            object param = new { PropertyId = value};
            return mySqlSingleton.Select<PropertyContextModel>(query, param);
        }

        public IEnumerable<PropertyContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetSelectAllQuery(_tableName);
            return mySqlSingleton.SelectAll<PropertyContextModel>(query);
        }

        public int Update(PropertyContextModel propertyContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetUpdateQuery(_tableName, propertyContextModel);
            return mySqlSingleton.Update(query, propertyContextModel);
        }
    }
}
