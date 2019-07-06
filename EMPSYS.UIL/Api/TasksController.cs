using EMPSYS.DAL;
using System.Linq;
using EMPSYS.DAL.Context;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EMPSYS.UIL.Api
{
    //[Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
				private readonly UnitOfWork _unitOfWork;

				public TaskController(AppContext context)
				{
						_unitOfWork = new UnitOfWork(context);
				}
				[Route("api/GetTasks")]
				[HttpGet]
						public ActionResult<List<object>> GetTasks()
						{
								//var _emp = _unitOfWork.InTasks.GetAll().Select(x => new { x.TaskId, x.Task1 }).ToList<object>();
								return _unitOfWork.InTasks.GetAll().Select(x => new { x.TaskId, x.Task1 }).ToList<object>();
						}

				//// GET: api/Task/5
				//				[HttpGet("{id}", Name = "Get")]
    //    public string Get(int id)
    //    {
    //        return "value";
    //    }

    //    // POST: api/Tasks
    //    [HttpPost]
    //    public void Post([FromBody] string value)
    //    {
    //    }

    //    // PUT: api/Tasks/5
    //    [HttpPut("{id}")]
    //    public void Put(int id, [FromBody] string value)
    //    {
    //    }

    //    // DELETE: api/ApiWithActions/5
    //    [HttpDelete("{id}")]
    //    public void Delete(int id)
    //    {
    //    }
    }
}
