using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DapperProje.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
    }
}