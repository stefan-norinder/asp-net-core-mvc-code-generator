﻿using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace CodeGeneratorExample.Logic.DataAccess
{

    public interface ISqlDataAccess
    {
        Task<T> LoadSingularData<T, U>(string sql, U parameters);
        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task SaveData<T>(string sql, T parameters);
        T LoadSingularDataSynchronous<T, U>(string sql, U parameters);
    }

    public class SqlDataAccess : ISqlDataAccess
    {
        private string _connectionString;
        private readonly ILogger logger;

        public SqlDataAccess(IConfiguration iconfiguration,
            ILogger<SqlDataAccess> logger)
        {
            _connectionString = iconfiguration.GetConnectionString("Default");
            this.logger = logger;
        }

        public async Task<T> LoadSingularData<T, U>(string sql, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    return await connection.QueryFirstOrDefaultAsync<T>(sql, parameters);
                }
                catch (Exception e)
                {
                    LogException(e);
                    connection.Close();
                    throw;
                }
            }
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var data = await connection.QueryAsync<T>(sql, parameters);
                    return data.AsList();
                }
                catch (Exception e)
                {
                    LogException(e);
                    connection.Close();
                    throw;
                }
            }
        }

        public T LoadSingularDataSynchronous<T, U>(string sql, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    return connection.QueryFirstOrDefault<T>(sql, parameters);
                }
                catch (Exception e)
                {
                    LogException(e);
                    connection.Close();
                    throw;
                }
            }
        }

        public async Task SaveData<T>(string sql, T parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    await connection.ExecuteAsync(sql, parameters);
                }
                catch (SqlException e)
                {
                    if (e.Message.Contains("Violation of UNIQUE KEY constraint"))
                    {
                        logger.LogWarning(e.Message);
                    }
                    else
                    {
                        LogException(e);
                        connection.Close();
                        throw;
                    }
                }
                catch (Exception e)
                {
                    LogException(e);
                    connection.Close();
                    throw;
                }
            }
        }

        #region private 

        private void LogException(Exception e)
        {
            logger.LogError(e, "An error occured when quering data from data source");
        }

        #endregion

    }
}