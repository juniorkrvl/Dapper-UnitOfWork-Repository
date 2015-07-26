using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using Dapper;

namespace DapperProje.Repository.Dapper.Common
{
    public class UnitOfWork : IDisposable
    {

        protected IDbConnection DbConnectionAsync;
        protected IDbTransaction DbTransaction;

        public UnitOfWork(bool requireTransaction = true)
        {
            var sb = new SqlConnectionStringBuilder(WebConfigurationManager.ConnectionStrings["MainDb"].ConnectionString) { AsynchronousProcessing = true }.ToString();
            DbConnectionAsync = new SqlConnection(sb);
            DbConnectionAsync.Open();
            if (requireTransaction)
            {
                BeginTransaction();
            }
        }

        public void BeginTransaction()
        {
            if (DbTransaction != null)
            {
                return;
            }
            DbTransaction = DbConnectionAsync.BeginTransaction();
        }
        public void CommitChanges()
        {
            if (DbTransaction != null)
            {
                DbTransaction.Commit();
            }
        }

        #region Dapper

        public Task<IEnumerable<T>> QueryAsync<T>(string sql, dynamic param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return SqlMapper.QueryAsync<T>(DbConnectionAsync, sql, param, DbTransaction, commandTimeout, commandType);
        }

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, dynamic param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            return SqlMapper.QueryAsync<TFirst, TSecond, TReturn>(DbConnectionAsync, sql, map, param, DbTransaction, buffered, splitOn, commandTimeout, commandType);
        }

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, dynamic param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            return SqlMapper.QueryAsync<TFirst, TSecond, TThird, TReturn>(DbConnectionAsync, sql, map, param, DbTransaction, buffered, splitOn, commandTimeout, commandType);
        }

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, dynamic param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            return SqlMapper.QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(DbConnectionAsync, sql, map, param, DbTransaction, buffered, splitOn, commandTimeout, commandType);
        }

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, dynamic param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            return SqlMapper.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(DbConnectionAsync, sql, map, param, DbTransaction, buffered, splitOn, commandTimeout, commandType);
        }

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, dynamic param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            return SqlMapper.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(DbConnectionAsync, sql, map, param, DbTransaction, buffered, splitOn, commandTimeout, commandType);
        }

        public Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, dynamic param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            return SqlMapper.QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(DbConnectionAsync, sql, map, param, DbTransaction, buffered, splitOn, commandTimeout, commandType);
        }

        public int Execute(string sql, dynamic param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return SqlMapper.Execute(DbConnectionAsync, sql, param, DbTransaction, commandTimeout, commandType);
        }

        public IEnumerable<dynamic> Query(string sql, dynamic param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return SqlMapper.Query(DbConnectionAsync, sql, param, DbTransaction, buffered, commandTimeout, commandType);
        }

        public IEnumerable<T> Query<T>(string sql, dynamic param = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null)
        {
            return SqlMapper.Query<T>(DbConnectionAsync, sql, param, DbTransaction, buffered, commandTimeout, commandType);
        }

        public SqlMapper.GridReader QueryMultiple(string sql, dynamic param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            return SqlMapper.QueryMultiple(DbConnectionAsync, sql, param, DbTransaction, commandTimeout, commandType);
        }

        public IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, dynamic param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            return SqlMapper.Query<TFirst, TSecond, TReturn>(DbConnectionAsync, sql, map, param, DbTransaction, buffered, splitOn, commandTimeout, commandType);
        }

        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(string sql, Func<TFirst, TSecond, TThird, TReturn> map, dynamic param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            return SqlMapper.Query<TFirst, TSecond, TThird, TReturn>(DbConnectionAsync, sql, map, param, DbTransaction, buffered, splitOn, commandTimeout, commandType);
        }

        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, dynamic param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            return SqlMapper.Query<TFirst, TSecond, TThird, TFourth, TReturn>(DbConnectionAsync, sql, map, param, DbTransaction, buffered, splitOn, commandTimeout, commandType);
        }

        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, dynamic param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            return SqlMapper.Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(DbConnectionAsync, sql, map, param, DbTransaction, buffered, splitOn, commandTimeout, commandType);
        }

        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, dynamic param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            return SqlMapper.Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(DbConnectionAsync, sql, map, param, DbTransaction, buffered, splitOn, commandTimeout, commandType);
        }

        public IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, dynamic param = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
            return SqlMapper.Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(DbConnectionAsync, sql, map, param, DbTransaction, buffered, splitOn, commandTimeout, commandType);
        }

        #endregion

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbTransaction != null)
                {
                    DbTransaction.Dispose();
                    DbTransaction = null;
                }
                if (DbConnectionAsync != null)
                {
                    DbConnectionAsync.Dispose();
                    DbConnectionAsync = null;
                }
            }
        }
        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}