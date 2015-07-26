using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DapperProje.Models;

namespace DapperProje.ModelViews
{
    public class UserModelView
    {
        public User User { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}