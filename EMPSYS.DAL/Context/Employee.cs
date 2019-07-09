using System;
using System.Collections.Generic;

namespace EMPSYS.DAL.Context
{
    public partial class Employee
    {
        public Employee()
        {
            CompletedHours = new HashSet<CompletedHour>();
            EmployeeTasks = new HashSet<EmployeeTask>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime HireDate { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<CompletedHour> CompletedHours { get; set; }
        public virtual ICollection<EmployeeTask> EmployeeTasks { get; set; }
    }
}