using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using Dapper;
using DapperProje.DapperHelper;
using DapperProje.Models;
using Microsoft.Ajax.Utilities;

namespace DapperProje.Repository.Dapper.Common
{


    public class GenericRepository<T> : UnitOfWork, IGenericRepository<T>
    {
        private readonly string _tableName;
        private readonly IDbConnection _con;
        private object _parameters;

        protected GenericRepository(string tableName)
        {
            _tableName = tableName;
            _con = DbConnectionAsync;
        }

        internal  dynamic Mapping(T obj)
        {
            return obj;
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var frmsql = GetSqlQuery.Select(_tableName);
            var list = await _con.QueryAsync<T>(frmsql, transaction: DbTransaction);
            return list;

        }

        public virtual  async Task<T> UpdateAsync(T obj)
        {
            _parameters = (object)Mapping(obj);
            var frmsql = GetSqlQuery.Update(_parameters, _tableName);
            var result = await _con.QueryAsync<T>(frmsql, _parameters, transaction: DbTransaction);
            return result.First();
        }

        public virtual async Task<bool> DeleteByIdAsync(int id)
        {
            var frmsql = GetSqlQuery.DeleteById(_tableName);
            var list = await _con.QueryAsync<T>(frmsql, new { Id = id }, transaction: DbTransaction);
            return Equals(list.FirstOrDefault(), 0);
        }

        public virtual async Task<int> AddAsync(T obj)
        {
            _parameters = (object)Mapping(obj);
            var frmsql = GetSqlQuery.Insert(_parameters, _tableName);
            var result = await _con.QueryAsync<int>(frmsql, _parameters, transaction: DbTransaction);
            return result.FirstOrDefault();
        }

        public Task<T> FindByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async  Task<T> FindAsync(T obj)
        {
            _parameters = (object)Mapping(obj);
            var frmsql = GetSqlQuery.Find(_parameters, _tableName);
            var result = await _con.QueryAsync<T>(frmsql, _parameters, transaction: DbTransaction);
            return result.FirstOrDefault();
        }
    }
}