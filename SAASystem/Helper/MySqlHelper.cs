using Dapper;
using MySqlConnector;
using SAASystem.Helper;
using System;
using System.Collections.Generic;
using System.IO;

public class MySqlHelper: IMySqlHelper
{
    MySqlConnection _mySqlConnection;
    public MySqlHelper()
    {
        string text = File.ReadAllText(@"C:\Users\Gayan\Desktop\key.txt");
        _mySqlConnection = new MySqlConnection(text);
    }
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
            if (param is null)
            {
                return _mySqlConnection.QueryFirstOrDefault<T>(query);
            }
            else
            {
                return _mySqlConnection.QueryFirstOrDefault<T>(query, param);
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
            if (param is null)
            {
                return _mySqlConnection.Query<T>(query);
            }
            else
            {
                return _mySqlConnection.Query<T>(query, param);
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
            if (param is null)
            {
                return _mySqlConnection.Execute(query);
            }
            else
            {
                return _mySqlConnection.Execute(query, param);
            }
        }
    }
}