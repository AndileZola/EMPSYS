using EMPSYS.DAL;
using EMPSYS.DAL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using AppContext = EMPSYS.DAL.Context.AppContext;

namespace EMPSYS.UIL.Api
{
		[Route("api/[controller]")]
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
        public ActionResult<List<object>> GetEmployees()
        {

												var _emp = _unitOfWork.InEmployees.EagerGetList(x => x.EmployeeId > 0, new List<string> { "Role", "EmployeeTasks" }).Select(x => new { x.EmployeeId, x.FirstName, x.LastName, x.Role.Role1,AssignedTasks = x.EmployeeTasks.Select(y=>y.TaskId),x.HireDate }).ToList<object>();
												return _emp;
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = _unitOfWork.InEmployees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public IActionResult PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _unitOfWork.InEmployees.Update(employee);

            try
            {
                _unitOfWork.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!EmployeeExists(id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }

            return Ok();
        }

        // POST: api/Employees
        [HttpPost]
        public ActionResult PostEmployee(Employee employee)
        {
            _unitOfWork.InEmployees.Add(employee);
            return _unitOfWork.SaveChanges() ? Ok() : BadRequest() as StatusCodeResult;
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

        //private bool EmployeeExists(int id)
        //{
        //    return _unitOfWork.InEmployees(e => e.EmployeeID == id);
        //}
    }
}
