using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UtsWebApi.Models.RequestResponse
{
    public class StaffServiceFindResponse
    {
        public StaffServiceFindResponse()
        {
            Employee = new Employee();
            Manager = new Employee();
            DirectReports = new List<Employee>();
        }

        public Employee Employee { get; set; }
        public Employee Manager { get; set; }
        public List<Employee> DirectReports { get; set; }
    }
}
