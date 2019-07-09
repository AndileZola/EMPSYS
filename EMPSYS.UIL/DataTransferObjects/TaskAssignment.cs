using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMPSYS.UIL.DataTransferObjects
{
		public class TaskAssignment
		{
				public int EmployeeId { get; set; }
				public int[] EmployeeTasks { get; set; }
		}
}
