using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CodeGenerator.Lib.DataAccess
{
    public interface IDataAccess
    {
        DataModel Get();
        public IEnumerable<Tuple<string, string>> GetColumnsWithDatatypes(string table);
        public IEnumerable<string> GetTableNames();
        string Database { get; }
    }

    public class SqlDataAccess : IDataAccess
    {
        private readonly string server;
        private readonly string userId;
        private readonly string password;

        public string Database { get; private set; }

        public SqlDataAccess(string server, string database, string userId = "", string password = "")
        {
            this.server = server;
            Database = database;
            this.userId = userId;
            this.password = password;
        }

        public DataModel Get()
        {
            var dataModel = GetDataModel();

            return GetDataModelPopulatedWithColumns(dataModel);
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

        private DataModel GetDataModelPopulatedWithColumns(DataModel dataModel)
        {
            var newDataModel = new DataModel();
            foreach (var item in dataModel.Tables)
            {
                var tuples = GetColumnsWithDatatypes(item.Name);
                var columns = tuples.Select(x => new Column { Name = x.Item1, SqlDataType = x.Item2 });
                newDataModel.Tables.Add(new Table { Name = item.Name, Columns = new List<Column>(columns)});
            }
            return newDataModel;
        }

        private DataModel GetDataModel()
        {
            return new DataModel
            {
                Tables = GetTableNames().Select(tableName => new Table { Name = tableName }).ToList()
            };
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
                InitialCatalog = Database
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

        private bool UserIdAndPasswordIsSet()
        {
            return !string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(password);
        }

        #endregion
    }
}