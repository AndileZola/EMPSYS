using System;
using System.Collections.Generic;

namespace EMPSYS.DAL.Context
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeTasks = new HashSet<EmployeeTask>();
        }

        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public int RoleID { get; set; }

        public virtual ICollection<EmployeeTask> EmployeeTasks { get; set; }
    }
}