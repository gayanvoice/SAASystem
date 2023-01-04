using SAASystem.Helper;
using SAASystem.Models.Context;
using System.Collections.Generic;

namespace SAASystem.Singleton
{
    public class RoomContextSingleton
    {
        private static RoomContextSingleton instance = null;

        private const string tableName = "Room";
        private static readonly object padlock = new object();
        RoomContextSingleton()
        {
        }
        public static RoomContextSingleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new RoomContextSingleton();
                    }
                    return instance;
                }
            }
        }
        public int Delete(int RoomId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(RoomId);
            string value = RoomId.ToString();
            string query = QueryHelper.GetDeleteQuery(tableName, column);
            object param = new { RoomId = value };
            return mySqlSingleton.Delete(query, param);
        }

        public int Insert(RoomContextModel roomContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetInsertQuery(tableName, roomContextModel);
            return mySqlSingleton.Insert(query, roomContextModel);
        }

        public RoomContextModel Select(int RoomId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(RoomId);
            string value = RoomId.ToString();
            string query = QueryHelper.GetSelectQuery(tableName, column);
            object param = new { RoomId = value };
            return mySqlSingleton.Select<RoomContextModel>(query, param);
        }

        public IEnumerable<RoomContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetSelectAllQuery(tableName);
            return mySqlSingleton.SelectAll<RoomContextModel>(query);
        }

        public int Update(RoomContextModel roomContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetUpdateQuery(tableName, roomContextModel);
            return mySqlSingleton.Update(query, roomContextModel);
        }
    }
}
