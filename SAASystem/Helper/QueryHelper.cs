using System.Linq;
using System.Reflection;
using System.Text;

namespace SAASystem.Helper
{
    public class QueryHelper
    {
        public static string GetDeleteQuery(string tableName, string columnName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("DELETE FROM ").Append(tableName).Append(" WHERE ").Append(columnName).Append(" IN (").Append(columnName).Append(")");
            return stringBuilder.ToString();
        }
        public static string GetInsertQuery<Type>(string tableName, Type type)
        {
            PropertyInfo lastPropertyInfo = type.GetType().GetProperties().Last();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("INSERT INTO ").Append(tableName).Append(" VALUES ").Append("(");
            foreach (PropertyInfo propertyInfo in type.GetType().GetProperties())
            {
                stringBuilder.Append(string.Concat("@", propertyInfo.Name));
                if (propertyInfo.Equals(lastPropertyInfo)) stringBuilder.Append(" ");
                else stringBuilder.Append(", ");
            }
            stringBuilder.Append(")");
            return stringBuilder.ToString();
        }
        public static string GetUpdateQuery<Type>(string tableName, Type type)
        {
            PropertyInfo firstPropertyInfo = type.GetType().GetProperties().First();
            PropertyInfo lastPropertyInfo = type.GetType().GetProperties().Last();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(string.Concat("UPDATE ", tableName, " SET "));
            foreach (PropertyInfo propertyInfo in type.GetType().GetProperties())
            {
                stringBuilder.Append(string.Concat(propertyInfo.Name, " = ", "@", propertyInfo.Name));
                if (propertyInfo.Equals(lastPropertyInfo)) stringBuilder.Append(" ");
                else stringBuilder.Append(", ");
            }
            stringBuilder.Append(string.Concat("WHERE ", firstPropertyInfo.Name, "  IN (@", firstPropertyInfo.Name, ")"));
            return stringBuilder.ToString();
        }
        public static string GetSelectQuery(string tableName, string columnName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM ").Append(tableName).Append(" WHERE ").Append(columnName).Append(" IN (").Append(columnName).Append(")");
            return stringBuilder.ToString();
        }
        public static string GetSelectAllQuery(string tableName)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT * FROM ").Append(tableName);
            return stringBuilder.ToString();
        }
    }
}