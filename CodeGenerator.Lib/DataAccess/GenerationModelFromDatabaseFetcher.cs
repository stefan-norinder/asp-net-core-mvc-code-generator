using CodeGenerator.Lib.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CodeGenerator.Lib.DataAccess
{

    public class GenerationModelFromDatabaseFetcher : ICodeGenerationModelFetcher
    {
        private readonly string server;
        private readonly string datasource;
        private readonly string userId;
        private readonly string password;

        public string Namespace { get; private set; }

        public GenerationModelFromDatabaseFetcher(string[] args)
        {
            Namespace = GetValueForArgument(ParamsConstants.Namespace, args);
            server = GetValueForArgument(ParamsConstants.Server, args);
            datasource = GetValueForArgument(ParamsConstants.DataSource, args);
            userId = GetValueForArgument(ParamsConstants.UserId, args);
            password = GetValueForArgument(ParamsConstants.Password, args);
        }

        private static string GetValueForArgument(string argument,string[] args)
        {
            if (!args.Any(x => x == argument)) return string.Empty;
            var serverIndex = Array.FindIndex(args, (str) =>
            {
                return str == argument;
            });
            return args[serverIndex + 1];
        }

        public CodeGenerationModel Get()
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

        private CodeGenerationModel GetDataModelPopulatedWithColumns(CodeGenerationModel dataModel)
        {
            var classes = new List<Class>();
            foreach (var item in dataModel.Classes)
            {
                var tuples = GetColumnsWithDatatypes(item.Name);
                var columns = tuples.Select(x => new Proprety { Name = x.Item1, DataType = x.Item2 });
                classes.Add(new Class { Name = item.Name, Properties = new List<Proprety>(columns) });
            }
            return new CodeGenerationModel(Namespace) { Classes = classes };
        }

        private CodeGenerationModel GetDataModel()
        {
            return new CodeGenerationModel(Namespace)
            {
                Classes = GetTableNames().Select(tableName => new Class { Name = tableName }).ToList()
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

        private bool UserIdAndPasswordIsSet()
        {
            return !string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(password);
        }

        #endregion
    }
}