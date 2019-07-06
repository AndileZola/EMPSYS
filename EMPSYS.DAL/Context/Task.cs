using System;
using System.Collections.Generic;

namespace EMPSYS.DAL.Context
{
    public partial class Task
    {
        public Task()
        {
            EmployeeTasks = new HashSet<EmployeeTask>();
        }

        public int TaskId { get; set; }
        public string Task1 { get; set; }
        public int Duration { get; set; }

        public virtual ICollection<EmployeeTask> EmployeeTasks { get; set; }
    }
}