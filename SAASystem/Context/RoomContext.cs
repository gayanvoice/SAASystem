using SAASystem.Context.Interface;
using SAASystem.Helper;
using SAASystem.Models.Context;
using SAASystem.Singleton;
using System.Collections.Generic;

namespace SAASystem.Context
{
    public class RoomContext : IRoomContext
    {
        private string _tableName = "Room";
        public int Delete(int RoomId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(RoomId);
            string value = RoomId.ToString();
            string query = QueryHelper.GetDeleteQuery(_tableName, column);
            object param = new { RoomId = value };
            return mySqlSingleton.Delete(query, param);
        }

        public int Insert(RoomContextModel roomContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetInsertQuery(_tableName, roomContextModel);
            return mySqlSingleton.Insert(query, roomContextModel);
        }

        public RoomContextModel Select(int RoomId)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string column = nameof(RoomId);
            string value = RoomId.ToString();
            string query = QueryHelper.GetSelectQuery(_tableName, column);
            object param = new { RoomId = value};
            return mySqlSingleton.Select<RoomContextModel>(query, param);
        }

        public IEnumerable<RoomContextModel> SelectAll()
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetSelectAllQuery(_tableName);
            return mySqlSingleton.SelectAll<RoomContextModel>(query);
        }

        public int Update(RoomContextModel roomContextModel)
        {
            MySqlSingleton mySqlSingleton = MySqlSingleton.Instance;
            string query = QueryHelper.GetUpdateQuery(_tableName, roomContextModel);
            return mySqlSingleton.Update(query, roomContextModel);
        }
    }
}
