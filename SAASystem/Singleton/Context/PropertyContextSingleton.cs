using SAASystem.Helper;
using SAASystem.Models.Context;
using System.Collections.Generic;

namespace SAASystem.Singleton
{
    public class PropertyContextSingleton
    {
        private static PropertyContextSingleton instance = null;

        private const string tableName = "Property";
        private static readonly object padlock = new object();
        PropertyContextSingleton()
        {
        }
        public static PropertyContextSingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new PropertyContextSingleton();
                    }
                    return instance;
                }
            }
        }
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
            object param = new { PropertyId = value };
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
