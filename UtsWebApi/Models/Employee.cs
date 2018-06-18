using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtsWebApi.Models
{
    public class Employee
    {
        public int? Id { get; set; }
        public string ImageUri { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public int?  ManagerId { get; set; } 
        public ContactInfo ContactInfo { get; set; }
        public int Likes { get; set; }
    }
}
