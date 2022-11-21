using System;
using System.Collections.Generic;

namespace SAASystem.Helper
{
    public interface IMySqlHelper
    {
        T Select<T>(string query);
        T Select<T>(string query, object param);
        IEnumerable<T> SelectAll<T>(string query);
        IEnumerable<T> SelectAll<T>(string query, object param);
        int Insert(string query);
        int Insert(string query, object param);
        int Update(string query);
        int Update(string query, object param);
        int Delete(string query);
        int Delete(string query, object param);
        string ConvertDateTimeToString(DateTime dateTime);
    }
}