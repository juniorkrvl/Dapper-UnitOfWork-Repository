using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using DapperProje.DapperHelper;

namespace DapperProje.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [Ignored]
        [ReadOnly(true)]
        public Address Address { get; set; }
    }

  

}