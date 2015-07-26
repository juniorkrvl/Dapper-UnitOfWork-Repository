using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperProje.Repository.Dapper.Common
{
  public  interface IUnitOfWork
    {
        void BeginTransaction();
        void CommitChanges();
    }
}
