using BICAPI.Common.Configs;
using BICAPI.Common.Exceptions;
using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace BICAPI.Common.SQLManager
{
    public class SqlRepository<T> : ISqlRepository<T> where T : class
    {
        public virtual T ExcuteSingle(string storeName, IDynamicParameters dyParam)
        {
            T result = null;
            try
            {
                using (var conn = GetConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            result = SqlMapper.QuerySingleOrDefault<T>(conn, storeName, param: dyParam, commandType: CommandType.StoredProcedure);
                        }
                        conn.Close();
                        conn.Dispose();
                    }
                    catch (Exception ex) 
                    {
                        conn.Close();
                        conn.Dispose();
                        throw new SqlDbException(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlDbException)
                    throw ex;
                throw new AppException(AppMessage.ConnectionFailed);
            }
            return result;
        }
        public virtual async Task<T> ExcuteSingleAsync(string storeName, IDynamicParameters dyParam)
        {
            T result = null;
            try
            {
                using (var conn = GetConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            result = await SqlMapper.QuerySingleOrDefaultAsync<T>(conn, storeName, param: dyParam, commandType: CommandType.StoredProcedure, commandTimeout: SqlConfig.CommandTimeOut);
                        }
                        conn.Close();
                        conn.Dispose();
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        conn.Dispose();
                        throw new SqlDbException(ex);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlDbException)
                    throw ex;
                throw new AppException(AppMessage.ConnectionFailed);
            }
            return result;
        }
        public virtual object ExcuteScalar(string storeName, IDynamicParameters dyParam)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            return SqlMapper.ExecuteScalar(conn, storeName, param: dyParam, commandType: CommandType.StoredProcedure);
                        }
                        conn.Close();
                        conn.Dispose();
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        conn.Dispose();
                        throw new SqlDbException(ex);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlDbException)
                    throw ex;
                throw new AppException(AppMessage.ConnectionFailed);
            }
            return null;
        }
        public virtual async Task<object> ExcuteScalarAsync(string storeName, IDynamicParameters dyParam)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            return await SqlMapper.ExecuteScalarAsync(conn, storeName, param: dyParam, commandType: CommandType.StoredProcedure, commandTimeout: SqlConfig.CommandTimeOut);
                        }
                        conn.Close();
                        conn.Dispose();
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        conn.Dispose();
                        throw new SqlDbException(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlDbException)
                    throw ex;
                throw new AppException(AppMessage.ConnectionFailed);
            }
            return null;
        }
        public virtual IEnumerable<T> ExcuteMany(string storeName, IDynamicParameters dyParam)
        {
            List<T> result = new List<T>();
            try
            {
                using (var conn = GetConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            var data = SqlMapper.Query<T>(conn, storeName, param: dyParam, commandType: CommandType.StoredProcedure);
                            if (data != null)
                            {
                                result = data.ToList();
                            }
                        }
                        conn.Close();
                        conn.Dispose();
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        conn.Dispose();
                        throw new SqlDbException(ex);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlDbException)
                    throw ex;
                throw new AppException(AppMessage.ConnectionFailed);
            }
            return result;
        }
        public virtual async Task<IEnumerable<T>> ExcuteManyAsync(string storeName, IDynamicParameters dyParam)
        {
            List<T> result = new List<T>();
            try
            {

                using (var conn = GetConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            var data = await SqlMapper.QueryAsync<T>(conn, storeName, param: dyParam, commandType: CommandType.StoredProcedure, commandTimeout: SqlConfig.CommandTimeOut);
                            if (data != null)
                            {
                                result = data.ToList();
                            }
                        }
                        conn.Close();
                        conn.Dispose();
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        conn.Dispose();
                        throw new SqlDbException(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlDbException)
                    throw ex;
                throw new AppException(AppMessage.ConnectionFailed);
            }
            return result;
        }
        public virtual int ExcuteNoneQuery(string storeName, IDynamicParameters dyParam)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            int result = SqlMapper.Execute(conn, storeName, param: dyParam, commandType: CommandType.StoredProcedure);
                            return result;
                        }
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        conn.Dispose();
                        throw new SqlDbException(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlDbException)
                    throw ex;
                throw new AppException(AppMessage.ConnectionFailed);
            }
            return 0;
        }
        public virtual async Task<int> ExcuteNoneQueryAsync(string storeName, IDynamicParameters dyParam)
        {
            int result = -1;
            try
            {
                using (var conn = GetConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            result = await SqlMapper.ExecuteAsync(conn, storeName, param: dyParam, commandType: CommandType.StoredProcedure, commandTimeout: SqlConfig.CommandTimeOut);
                            return result;
                        }
                        conn.Close();
                        conn.Dispose();
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        conn.Dispose();
                        throw new SqlDbException(ex);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlDbException)
                    throw ex;
                throw new AppException(AppMessage.ConnectionFailed);
            }
            return result;
        }
        public virtual void ExcuteMultiple(string storeName, IDynamicParameters dyParam, Action<GridReader> action)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            using (var multi = conn.QueryMultiple(storeName, dyParam, null, null, CommandType.StoredProcedure))
                            {
                                action(multi);
                            }
                        }
                        conn.Close();
                        conn.Dispose();
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        conn.Dispose();
                        throw new SqlDbException(ex);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlDbException)
                    throw ex;
                throw new AppException(AppMessage.ConnectionFailed);
            }
        }
        public virtual async Task ExcuteMultipleAsync(string storeName, IDynamicParameters dyParam, Action<GridReader> action)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    try
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            using (var multi = await conn.QueryMultipleAsync(storeName, dyParam, null, SqlConfig.CommandTimeOut, CommandType.StoredProcedure))
                            {
                                action(multi);
                            }
                        }
                        conn.Close();
                        conn.Dispose();
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        conn.Dispose();
                        throw new SqlDbException(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is SqlDbException)
                    throw ex;
                throw new AppException(AppMessage.ConnectionFailed);
            }

        }
        public IDbConnection GetConnection()
        {
            if (SqlConfig.ConnectionString != null)
            {
                var conn = new SqlConnection(SqlConfig.ConnectionString);
                return conn;
            }
            return null;
        }
    }
}
