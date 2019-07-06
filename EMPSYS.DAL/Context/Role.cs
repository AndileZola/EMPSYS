using System;
using System.Collections.Generic;

namespace EMPSYS.DAL.Context
{
    public partial class Role
    {
        public Role()
        {
            Employees = new HashSet<Employee>();
        }

        public int RoleId { get; set; }
        public string Role1 { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}