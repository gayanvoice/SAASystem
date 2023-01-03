using SAASystem.Context.Interface;
using SAASystem.Helper;
using SAASystem.Models.Context;
using SAASystem.Singleton;
using System.Collections.Generic;

namespace SAASystem.Context
{
    public class ApartmentContext : IApartmentContext
    {
        private string _tableName = "Apartment";
        public int Delete(int ApartmentId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(ApartmentId);
            string value = ApartmentId.ToString();
            string query = QueryHelper.GetDeleteQuery(_tableName, column);
            object param = new { ApartmentId = value };
            return mySqlSingleton.Delete(query, param);
        }

        public int Insert(ApartmentContextModel apartmentContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetInsertQuery(_tableName, apartmentContextModel);
            return mySqlSingleton.Insert(query, apartmentContextModel);
        }

        public ApartmentContextModel Select(int ApartmentId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(ApartmentId);
            string value = ApartmentId.ToString();
            string query = QueryHelper.GetSelectQuery(_tableName, column);
            object param = new { ApartmentId = value};
            return mySqlSingleton.Select<ApartmentContextModel>(query, param);
        }

        public IEnumerable<ApartmentContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetSelectAllQuery(_tableName);
            return mySqlSingleton.SelectAll<ApartmentContextModel>(query);
        }

        public int Update(ApartmentContextModel apartmentContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetUpdateQuery(_tableName, apartmentContextModel);
            return mySqlSingleton.Update(query, apartmentContextModel);
        }
    }
}
