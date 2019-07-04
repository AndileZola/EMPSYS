﻿using System;
using System.Collections.Generic;

namespace EMPSYS.DAL.Context
{
    public partial class EmployeeTask
    {
        public int ID { get; set; }
        public int TaskID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime DateAssigned { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Task Task { get; set; }
    }
}