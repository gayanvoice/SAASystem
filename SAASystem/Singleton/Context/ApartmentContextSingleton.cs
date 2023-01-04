using SAASystem.Helper;
using SAASystem.Models.Context;
using System.Collections.Generic;

namespace SAASystem.Singleton
{
    public class ApartmentContextSingleton
    {
        private static ApartmentContextSingleton instance = null;

        private const string tableName = "Apartment";
        private static readonly object padlock = new object();
        ApartmentContextSingleton()
        {
        }
        public static ApartmentContextSingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ApartmentContextSingleton();
                    }
                    return instance;
                }
            }
        }
        public int Delete(int ApartmentId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(ApartmentId);
            string value = ApartmentId.ToString();
            string query = QueryHelper.GetDeleteQuery(tableName, column);
            object param = new { ApartmentId = value };
            return mySqlSingleton.Delete(query, param);
        }
        public int Insert(ApartmentContextModel apartmentContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetInsertQuery(tableName, apartmentContextModel);
            return mySqlSingleton.Insert(query, apartmentContextModel);
        }
        public ApartmentContextModel Select(int ApartmentId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(ApartmentId);
            string value = ApartmentId.ToString();
            string query = QueryHelper.GetSelectQuery(tableName, column);
            object param = new { ApartmentId = value };
            return mySqlSingleton.Select<ApartmentContextModel>(query, param);
        }
        public IEnumerable<ApartmentContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetSelectAllQuery(tableName);
            return mySqlSingleton.SelectAll<ApartmentContextModel>(query);
        }
        public int Update(ApartmentContextModel apartmentContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetUpdateQuery(tableName, apartmentContextModel);
            return mySqlSingleton.Update(query, apartmentContextModel);
        }
    }
}
