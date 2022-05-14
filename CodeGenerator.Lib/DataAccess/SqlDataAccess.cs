using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CodeGenerator.Lib.DataAccess
{
    public class SqlDataAccess
    {
        private readonly string server;
        private readonly string database;
        private readonly string userId;
        private readonly string password;

        public SqlDataAccess(string server, string database, string userId = "", string password = "")
        {
            this.server = server;
            this.database = database;
            this.userId = userId;
            this.password = password;
        }

        public IEnumerable<string> GetTableNames()
        {
            return ExecuteQuery("select distinct table_name from information_schema.columns", GetStringFromReader);
        }

        public IEnumerable<Tuple<string, string>> GetColumnsWithDatatypes(string table)
        {
            return ExecuteQuery($"select column_name, data_type from information_schema.columns where table_name = '{table}'", GetTupleFromReader);
        }


        #region private

        private IEnumerable<T> ExecuteQuery<T>(string sql, Func<SqlDataReader, T> func)
        {
            using (var connection = GetSqlConnection())
            {
                connection.Open();

                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return func(reader);
                        }
                    }
                }
            }
            yield break;
        }

        static string GetStringFromReader(SqlDataReader reader)
        {
            return $"{reader.GetString(0)}";
        }

        static Tuple<string, string> GetTupleFromReader(SqlDataReader reader)
        {
            string item1 = reader.GetString(0);
            string item2 = reader.GetString(1);
            return new Tuple<string, string>(item1, item2);
        }
        private SqlConnection GetSqlConnection()
        {
            var builder = GetSqlBuilder();

            return new SqlConnection(builder.ConnectionString);
        }

        private SqlConnectionStringBuilder GetSqlBuilder()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = server;
            builder.InitialCatalog = database;
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(password))
            {
                builder.IntegratedSecurity = true;
            }
            else
            {
                builder.UserID = "<your_username>";
                builder.Password = "<your_password>";
            }

            return builder;
        }

        #endregion
    }
}