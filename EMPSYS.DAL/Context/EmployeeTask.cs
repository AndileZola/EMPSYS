using System;
using System.Collections.Generic;

namespace EMPSYS.DAL.Context
{
    public partial class EmployeeTask
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateAssigned { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Task Task { get; set; }
    }
}