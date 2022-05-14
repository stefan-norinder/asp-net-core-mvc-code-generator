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

        public IEnumerable<string> ExecuteQuery()
        {
            return ExecuteQuery("select distinct table_name from information_schema.columns");
        }

        public IEnumerable<string> ExecuteQuery(string sql)
        {
            using (var connection = GetSqlConnection())
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return $"{reader.GetString(0)}";
                        }
                    }
                }
            }
            yield break;
        }

        #region private

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