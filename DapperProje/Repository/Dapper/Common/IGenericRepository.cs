using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperProje.Repository.Dapper.Common
{
    interface IGenericRepository<T>
    {
        #region operations async
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> UpdateAsync(T obj);
        Task<bool> DeleteAsync(int id);
        Task<object> AddAsync(T obj);
        Task<T> FindByIdAsync(int id);
        Task<T> FindAsync(T obj);
        #endregion
    }
}
