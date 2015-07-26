using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Dapper;
using DapperProje.Models;
using DapperProje.Repository.Dapper.Common;

namespace DapperProje.Repository.Dapper
{
    public class UserRepository:GenericRepository<User>,IUserRepository
    {
        public UserRepository() : base("User")
        {
        }

        public async Task<bool> AddUserWithAddress(User usr)
        {
            var con = DbConnectionAsync;
             string sql =      "INSERT INTO [User] (Name,Email) VALUES(@Name,@Email);DECLARE @UserId INT;" +
                               "SET @UserId=CAST(SCOPE_IDENTITY() AS INT);" +
                               "INSERT INTO [Address] (Id,City,Location) VALUES(@UserId,@City,@Location);" +
                               "SELECT @UserId";
             //be sure that you add transaction in QueryAsync
            var result= await  con.QueryAsync<int>(sql,new
            {
                Name=usr.Name,Email=usr.Email,
                City=usr.Address.City,Location=usr.Address.Location
            },transaction:DbTransaction);

            return result.FirstOrDefault() > 0;

        }

        public async Task<bool>  DeleteUserWithAddress(int userId)
        {
            var con = DbConnectionAsync;
            string sql = "DELETE  FROM [Address] WHERE Id=@Id;" +
                         " DELETE  FROM [User] WHERE Id=@Id;";
            var result = await con.QueryAsync<int>(sql, new {Id=userId}, transaction: DbTransaction);
            return result.FirstOrDefault() == 0;
            
        }

        public async Task<User> GetUserDetail(int userId)
        {
            var con = DbConnectionAsync;
            string sql = "SELECT u.*,a.* FROM [User] u" +
                         "INNER JOIN [Address] a ON a.Id=u.Id WHERE u.Id=@Id";
            var result = await con.QueryAsync<User, Address, User>(sql, (u, a) =>
            {
                u.Address = a;
                return u;
            }, new { Id = userId }, transaction: DbTransaction);
            return result.FirstOrDefault();
        }
    }
}