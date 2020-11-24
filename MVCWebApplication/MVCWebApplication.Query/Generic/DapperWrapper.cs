using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MVCWebApplication.Query.Generic
{
    public class DapperWrapper : IDapperWrapper
    {
        private readonly QueriesConnectionString _queriesConnectionString;
        public DapperWrapper(QueriesConnectionString queriesConnectionString)
        {
            _queriesConnectionString = queriesConnectionString;
        }

        public IEnumerable<T> Query<T>(string sql, object param = null, bool buffered = true, int? commandTimeout = null)
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                return dbConnection.Query<T>(sql, param, buffered: buffered, commandTimeout: commandTimeout);
            }
        }
        public List<T> GetAll<T>(string sql, object param = null, bool buffered = true, int? commandTimeout = null)
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                return dbConnection.Query<T>(sql, param, buffered: buffered, commandTimeout: commandTimeout).ToList();
            }
        }

        public IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null)
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                return dbConnection.Query<TFirst, TSecond, TReturn>(sql, map, param, buffered: buffered, commandTimeout: commandTimeout, splitOn: splitOn);
            }
        }

        public T QueryFirst<T>(string sql, object param = null, int? commandTimeout = null)
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                return dbConnection.QueryFirst<T>(sql, param, commandTimeout: commandTimeout);
            }
        }

        public T QueryFirstOrDefault<T>(string sql, object param = null, int? commandTimeout = null)
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                return dbConnection.QueryFirstOrDefault<T>(sql, param, commandTimeout: commandTimeout);
            }
        }

        private IDbConnection GetConnection()
        {
            return new SqlConnection(_queriesConnectionString.Value);
        }
     
        public T Insert<T>(string sql, object param = null, bool buffered = true, int? commandTimeout = null)
        {
            T result;
            using (IDbConnection dbConnection = GetConnection())
            {
                try
                {
                    if (dbConnection.State == ConnectionState.Closed)
                        dbConnection.Open();

                    using (var tran = dbConnection.BeginTransaction())
                    {
                        try
                        {
                            result = dbConnection.Query<T>(sql, param, commandTimeout: commandTimeout).FirstOrDefault();
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw ex;
                        }
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    if (dbConnection.State == ConnectionState.Open)
                        dbConnection.Close();
                }

                return result;
            }
        }

        public T Update<T>(string sql, object param = null, bool buffered = true, int? commandTimeout = null)
        {
            T result;
            using (IDbConnection db = GetConnection())
            {
                try
                {
                    if (db.State == ConnectionState.Closed)
                        db.Open();

                    using (var tran = db.BeginTransaction())
                    {
                        try
                        {
                            result = db.Query<T>(sql, param, commandTimeout: commandTimeout).FirstOrDefault();
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            throw ex;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (db.State == ConnectionState.Open)
                        db.Close();
                }

                return result;
            }
        }
        
    }
}

