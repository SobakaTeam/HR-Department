using HR_Department.APIv2.Controllers.BaseControllers;
using HR_Department.APIv2.DBModels;
using Microsoft.AspNetCore.Mvc;

namespace HR_Department.APIv2.Controllers.JunctionControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonDepartmentController : BaseJunctionController
    {
        public PersonDepartmentController(AppDbContext context) : base(context)
        {
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDepartment>>> Get()
        {
            return await GetJunction<PersonDepartment>();
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<PersonDepartment>> GetById(long Id)
        {
            return await GetJunctionById< PersonDepartment>(Id);
        }
        [HttpPost]
        public async Task<ActionResult<PersonDepartment>> Post(long PersonId, long DepartmentId)
        {
            return await CreateJunction<PersonDepartment, Person, Department>(PersonId, DepartmentId);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(long Id)
        {
            return await DeleteJunction<PersonDepartment>(Id);
        }

    }
}
