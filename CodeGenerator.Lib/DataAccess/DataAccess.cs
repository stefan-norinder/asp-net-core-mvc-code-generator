using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CodeGenerator.Lib.DataAccess
{
    public interface IDataAccess
    {
        void Initilize(string server, string datasource, string userId = "", string password = "");
        IEnumerable<string> GetTableNames();
        IEnumerable<Tuple<string, string>> GetColumnsWithDatatypes(string table);
        bool HasIdentityColumn(string tableName);
    }

    public class DataAccess : IDataAccess
    {
        private string server;
        private string datasource;
        private string userId;
        private string password;

        public void Initilize(string server, string datasource, string userId = "", string password = "")
        {
            this.server = server;
            this.datasource = datasource;
            this.userId = userId;
            this.password = password;
        }

        public IEnumerable<string> GetTableNames()
        {
            CheckInitialization();
            return ExecuteQuery("select distinct table_name from information_schema.columns", GetStringFromReader);
        }

        public IEnumerable<Tuple<string, string>> GetColumnsWithDatatypes(string table)
        {
            CheckInitialization();
            return ExecuteQuery($"select column_name, data_type from information_schema.columns where table_name = '{table}'", GetTupleFromReader);
        }

        public bool HasIdentityColumn(string tableName)
        {
            CheckInitialization();
            var sql = @$"select b.name as IdentityColumn 
                        from    sysobjects a inner join syscolumns b on a.id = b.id 
                       where a.name = '{tableName}' and    
                            columnproperty(a.id, b.name, 'isIdentity') = 1 and 
                            objectproperty(a.id, 'isTable') = 1";
            var result = ExecuteQuery(sql, GetStringFromReader);
            return result.Any();
        }

        #region private

        private void CheckInitialization()
        {
            if (string.IsNullOrEmpty(server) || string.IsNullOrEmpty(datasource)) throw new ArgumentException("Data access not initialized.");
        }

        private IEnumerable<T> ExecuteQuery<T>(string sql, Func<SqlDataReader, T> getDataFromReaderFunction)
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
                            yield return getDataFromReaderFunction(reader);
                        }
                    }
                }
            }
            yield break;
        }


        private SqlConnection GetSqlConnection()
        {
            var builder = GetSqlBuilder();

            return new SqlConnection(builder.ConnectionString);
        }

        private SqlConnectionStringBuilder GetSqlBuilder()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = server,
                InitialCatalog = datasource
            };

            if (UserIdAndPasswordIsSet())
            {
                builder.UserID = userId;
                builder.Password = password;
            }
            else
            {
                builder.IntegratedSecurity = true;
            }

            return builder;
        }

        private static string GetStringFromReader(SqlDataReader reader)
        {
            return $"{reader.GetString(0)}";
        }


        private static Tuple<string, string> GetTupleFromReader(SqlDataReader reader)
        {
            string item1 = reader.GetString(0);
            string item2 = reader.GetString(1);
            return new Tuple<string, string>(item1, item2);
        }

        private bool UserIdAndPasswordIsSet()
        {
            return !string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(password);
        }

        #endregion
    }
}
