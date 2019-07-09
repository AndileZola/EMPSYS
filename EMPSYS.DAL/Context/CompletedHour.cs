using System;
using System.Collections.Generic;

namespace EMPSYS.DAL.Context
{
    public partial class CompletedHour
    {
        public int Id { get; set; }
        public int Hours { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }

        public virtual Employee Employee { get; set; }
    }
}