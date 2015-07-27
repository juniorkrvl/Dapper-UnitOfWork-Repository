using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperProje.Models;
using DapperProje.Repository.Dapper.Common;

namespace DapperProje.Repository.Dapper
{
    interface IUserRepository : IGenericRepository<User>, IUnitOfWork
    {

        Task<bool> AddUserWithAddress(User usr);
        Task<bool> DeleteUserWithAddress(int userId);
        Task<User> GetUserDetail(int userId);
    }
}
