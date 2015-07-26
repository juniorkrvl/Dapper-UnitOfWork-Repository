using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using Dapper;
using Microsoft.Ajax.Utilities;

namespace DapperProje.Repository.Dapper.Common
{
   

    public class GenericRepository<T> : UnitOfWork, IGenericRepository<T>
    {
        private string _tableName;
        protected GenericRepository(string tableName)
        {
            _tableName = tableName;
        }
        internal virtual dynamic Mapping(T obj)
        {
            return obj;
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var con = DbConnectionAsync;
            var sql = "SELECT * FROM ["+_tableName+"]";
            var list = await con.QueryAsync<T>(sql,transaction:DbTransaction);
            return list;

        }

        public Task<T> UpdateAsync(T obj)
        {
            throw new System.NotImplementedException();
        }

        public virtual  async Task<bool> DeleteAsync(int id)
        {
            var con = DbConnectionAsync;
            var sql = "DELETE FROM [" + _tableName + "] WHERE Id=@Id";
            var list = await con.QueryAsync<T>(sql,new {Id=id}, transaction: DbTransaction);
            return Equals(list.FirstOrDefault(), 0);
        }

        public virtual  async Task<object> AddAsync(T obj)
        {
            //var con = DbConnectionAsync;
            //var parameters = (object)Mapping(obj);

            //PropertyInfo[] paraminfos = parameters.GetType().GetProperties();
            //string[] colums = paraminfos.Select(m => m.Name).Where(n => n != "Id").ToArray();
            //var sql = "INSERT INTO " +_tableName + "({0}) VALUES(@{1});SELECT CAST(SCOPE_IDENTITY() AS INT)";
            //var frmsql = String.Format(sql, String.Join(",", colums),String.Join(",@",colums));
            
            //var result = await con.QueryAsync<T>(frmsql,parameters);
            //return result.First();
            throw new System.NotImplementedException();
        }

        public Task<T> FindByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> FindAsync(T obj)
        {
            throw new System.NotImplementedException();
        }
    }
}