using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Dapper;

namespace DapperProje.Repository.Dapper.Common
{
   

    public class GenericRepository<T> : UnitOfWork, IGenericRepository<T>
    {
        private string _tableName;
        protected GenericRepository(string tableName)
        {
            _tableName = tableName;
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

        public Task<bool> DeleteAsync(T obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AddAsync(T obj)
        {
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