using EMPSYS.DAL;
using EMPSYS.DAL.Context;
using EMPSYS.UIL.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using AppContext = EMPSYS.DAL.Context.AppContext;

namespace EMPSYS.UIL.Api
{
		//[Route("api/[controller]")]
		[Produces("application/json")]
		[ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public EmployeesController(AppContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

				// GET: api/Employees
				[HttpGet]
				[Route("api/GetEmployees")]
    public ActionResult<List<object>> GetEmployees()
    {
							var _emp = _unitOfWork.InEmployees.EagerGetList(x => x.EmployeeId > 0, new List<string> { "Role", "EmployeeTasks.Task" })
											.Select(x => new { x.EmployeeId, x.FirstName, x.LastName, Role = new { x.Role.Role1, x.Role.RoleId }, AssignedTasks = x.EmployeeTasks.Select(y => y.TaskId), Salary = x.Role.Rate * x.EmployeeTasks.Sum(y => y.Task.Duration), x.HireDate }).ToList<object>();

						//.Select(x => new { x.EmployeeId, x.FirstName, x.LastName, Role=new { x.Role.Role1, x.Role.RoleId }, AssignedTasks = x.EmployeeTasks.Select(y => y.TaskId),Hours=x.EmployeeTasks.Sum(y=>y.Task.Duration),Salary=x.Role.Rate * x.EmployeeTasks.Sum(y => y.Task.Duration), x.HireDate }).ToList<object>();
						return _emp;
    }
       
				// PUT: api/Employees/5
				[HttpPost]
				[Route("api/UpdateEmployee")]
				public IActionResult UpdateEmployee(EmployeeDTO employeedto)
				{
						CompletedHour completedHour = new CompletedHour{Hours = employeedto.Hours,Date = DateTime.Now};
						Employee _UpdatedEmployee = ConvertDtoToEmployee(employeedto);
						Employee _OldEmployee = _unitOfWork.InEmployees.Find(employeedto.EmployeeId);
						_UpdatedEmployee.CompletedHours.Add(completedHour);
						_OldEmployee = _UpdatedEmployee;
						_unitOfWork.InEmployees.Update(_OldEmployee);
						try
						{
								bool isSaved = _unitOfWork.SaveChanges();
								return Ok(isSaved);
						}catch(DbUpdateException ex){
								return BadRequest();
						}
																					
				}

				// POST: api/AddEmployee
				[HttpPost]
				[Route("api/AddEmployee")]
				public ActionResult PostEmployee(EmployeeDTO employeedto)
    {
							Employee _UpdatedEmployee = ConvertDtoToEmployee(employeedto);
						_unitOfWork.InEmployees.Add(_UpdatedEmployee);
						var isSaved = _unitOfWork.SaveChanges();
						return Ok(isSaved);								
					}

				[HttpPost]
				[Route("api/AssignTasks")]
				public ActionResult AssignTasks(TaskAssignment taskAssignment)
				{
						List<EmployeeTask> employeeTask = new List<EmployeeTask>();
						taskAssignment.EmployeeTasks.ToList().ForEach(x=> { employeeTask.Add(new EmployeeTask { TaskId = x, EmployeeId = taskAssignment.EmployeeId }); });
						List<EmployeeTask> _OldTasks = _unitOfWork.InEmployeeTasks.Find(x => x.EmployeeId == taskAssignment.EmployeeId).ToList();
						if(_OldTasks.Count > 0)
								_unitOfWork.InEmployeeTasks.RemoveRange(_OldTasks);
						if(employeeTask.Count > 0)
								_unitOfWork.InEmployeeTasks.AddRange(employeeTask);
						var isSaved = _unitOfWork.SaveChanges();
						return Ok(isSaved);
				}

				// DELETE: api/Employees/5
				[HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var employee = _unitOfWork.InEmployees.Find(id);
            if (employee == null){
                return NotFound();
            }

            _unitOfWork.InEmployees.Remove(employee);

            return _unitOfWork.SaveChanges() ? Ok() : BadRequest() as StatusCodeResult;
        }

        [NonAction]
				Employee ConvertDtoToEmployee(EmployeeDTO employeedto){
						List<EmployeeTask> employeeTasks = new List<EmployeeTask>();
						//if (employeedto.EmployeeTasks.Length > 0)
						//		employeedto.EmployeeTasks.ToList().ForEach(x => employeeTasks.Add(new EmployeeTask { TaskId = x }));
					return new Employee{
								FirstName = employeedto.FirstName,
								LastName = employeedto.LastName,
								RoleId = employeedto.RoleId,
								//EmployeeTasks = employeeTasks
						};
				}
    }
}
