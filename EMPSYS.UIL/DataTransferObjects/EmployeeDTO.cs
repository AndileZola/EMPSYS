using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMPSYS.UIL.DataTransferObjects
{
		public class EmployeeDTO
		{
				public int EmployeeId { get; set; }
				public string FirstName { get; set; }
				public string LastName { get; set; }
				public int RoleId { get; set; }
				public int[] EmployeeTasks { get; set; }
		}
}
