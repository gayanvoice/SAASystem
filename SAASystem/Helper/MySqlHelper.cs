using Dapper;
using SAASystem.Helper;
using SAASystem.Singleton;
using System;
using System.Collections.Generic;

public class MySqlHelper: IMySqlHelper
{
    public T Select<T>(string query)
    {
        return QueryFirstOrDefault<T>(query, null);
    }
    public T Select<T>(string query, object param)
    {
        return QueryFirstOrDefault<T>(query, param);
    }
    public IEnumerable<T> SelectAll<T>(string query)
    {
        return Query<T>(query, null);
    }
    public IEnumerable<T> SelectAll<T>(string query, object param)
    {
        return Query<T>(query, param);
    }
    public int Insert(string query)
    {
        return Execute(query, null);
    }
    public int Insert(string query, object param)
    {
        return Execute(query, param);
    }
    public int Update(string query)
    {
        return Execute(query, null);
    }
    public int Update(string query, object param)
    {
        return Execute(query, param);
    }
    public int Delete(string query)
    {
        return Execute(query, null);
    }
    public int Delete(string query, object param)
    {
        return Execute(query, param);
    }
    public string ConvertDateTimeToString(DateTime dateTime)
    {
        return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
    }
    public T QueryFirstOrDefault<T>(string query, object param)
    {
        if (query is null)
        {
            throw new ArgumentNullException();
        }
        else
        {
            DatabaseSingleton databaseSingleton = DatabaseSingleton.Instance;
            if (param is null)
            {
                return databaseSingleton.MySqlConnection.QueryFirstOrDefault<T>(query);
            }
            else
            {
                return databaseSingleton.MySqlConnection.QueryFirstOrDefault<T>(query, param);
            }
        }
    }
    public IEnumerable<T> Query<T>(string query, object param)
    {
        if (query is null)
        {
            throw new ArgumentNullException();
        }
        else
        {
            DatabaseSingleton databaseSingleton = DatabaseSingleton.Instance;
            if (param is null)
            {
                return databaseSingleton.MySqlConnection.Query<T>(query);
            }
            else
            {
                return databaseSingleton.MySqlConnection.Query<T>(query, param);
            }
        }
    }
    private int Execute(string query, object param)
    {
        if (query is null)
        {
            throw new ArgumentNullException();
        }
        else
        {
            DatabaseSingleton databaseSingleton = DatabaseSingleton.Instance;
            if (param is null)
            {
                return databaseSingleton.MySqlConnection.Execute(query);
            }
            else
            {
                return databaseSingleton.MySqlConnection.Execute(query, param);
            }
        }
    }
}