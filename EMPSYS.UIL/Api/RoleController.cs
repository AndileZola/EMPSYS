using EMPSYS.DAL;
using System.Linq;
using EMPSYS.DAL.Context;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EMPSYS.UIL.Api
{
		[Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
				private readonly UnitOfWork _unitOfWork;

				public RoleController(AppContext context)
				{
						_unitOfWork = new UnitOfWork(context);
				}
				// GET: api/GetRoles
				[HttpGet]
						public ActionResult<List<object>> GetRoles()
						{
								var _emp = _unitOfWork.InRoles.GetAll().Select(x => new { x.RoleId, x.Role1}).ToList<object>();
								return _emp;
						}

						// GET: api/Role/5
								[HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Role
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Role/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
