﻿using CodeGeneratorExample.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CodeGeneratorExample.Logic.DataAccess
{
    public class SqlStringBuilder<T>
    {
        private BuilderType type;

        private enum BuilderType
        {
            Insert = 1,
            Update = 2
        }

        public string GetInsertString(T entity)
        {
            type = BuilderType.Insert;
            var dictionary = GetDictionary(entity);
            return dictionary.CreateInsertString<T>();
        }

        public string GetUpdateString(T entity)
        {
            type = BuilderType.Update;
            var dictionary = GetDictionary(entity);
            return dictionary.CreateUpdateString<T>();
        }

        #region private

        private Dictionary<string, string> GetDictionary(T entity)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (PropertyInfo pi in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if ((type == BuilderType.Insert || type == BuilderType.Update) && pi.GetCustomAttribute(typeof(SqlInsertIgnoreAttribute)) != null) continue;
                string value;
                if (pi.PropertyType == typeof(DateTime) && (PropertyIsNull(entity, pi) || PropertyIsDateTimeNullRepresentation(entity, pi)))
                {
                    value = null;
                }
                else if (PropertyIsNull(entity, pi))
                {
                    value = null;
                }
                else if (pi.PropertyType == typeof(string))
                {
                    var str = pi.GetValue(entity).ToString();
                    value = str.Replace("'", "''");
                }
                else
                {
                    value = pi.GetValue(entity).ToString();
                }
                dictionary.Add(pi.Name, value);
            }

            return dictionary;
        }

        private static bool PropertyIsDateTimeNullRepresentation(T entity, PropertyInfo pi)
        {
            DateTime dateTime;
            var entityAsString = pi.GetValue(entity).ToString();
            if (!DateTime.TryParse(entityAsString, out dateTime))
            {
                return false;
            }
            return dateTime == DateTime.MinValue;
        }

        private static bool PropertyIsNull(T entity, PropertyInfo pi)
        {
            return pi.GetValue(entity) == null;
        }

        #endregion
    }

    public static partial class StringExtentions
    {
        public static string RemoveLast(this string str, int numberOfCharactersToRemove)
        {
            return str.Remove(str.Length - numberOfCharactersToRemove);
        }
    }

    public static partial class DictionaryExtentions
    {
        public static string CreateInsertString<T>(this Dictionary<string, string> dictionary)
        {
            var insertStringHead = $"insert into {typeof(T).Name} (";
            var insertStringTail = "values (";
            foreach (var item in dictionary)
            {
                insertStringHead += $"[{item.Key}], ";
                var value = dictionary[item.Key];
                insertStringTail += value == null ? "NULL, " : "'" + value + "', ";
            }
            insertStringHead = insertStringHead.RemoveLast(2);
            insertStringTail = insertStringTail.RemoveLast(2);

            return insertStringHead + ") " + insertStringTail + ")";
        }

        public static string CreateUpdateString<T>(this Dictionary<string, string> dictionary)
        {
            var updateString = $"update {typeof(T).Name} set ";
            foreach (var item in dictionary.Where(x => x.Key != "Id"))
            {
                var value = dictionary[item.Key];

                var valueString = value == null ? "NULL, " : "'" + value + "', ";

                updateString += $"[{item.Key}] = {valueString}";

            }
            updateString = updateString.RemoveLast(2);

            updateString += " where Id = " + dictionary["Id"];

            return updateString;
        }
    }
}
