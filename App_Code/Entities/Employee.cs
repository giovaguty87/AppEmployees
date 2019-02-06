using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


    /// <summary>
    /// Employees
    /// </summary>
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string contractTypeName { get; set; }
        public int roleId { get; set; }
        public string roleDescription { get; set; }
        public string hourlySalary { get; set; }
        public string monthlySalary { get; set; }
        public string totalSalary { get; set; }

    }
