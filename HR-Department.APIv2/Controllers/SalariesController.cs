using HR_Department.APIv2.Controllers.BaseController;
using HR_Department.APIv2.DBModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HR_Department.APIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalariesController : MyApiController
    {
        public SalariesController(AppDbContext context) : base(context)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salary>>> Get([FromQuery] Dictionary<string, string> properties,
            [FromHeader] string? orderBy, [FromHeader] SortOrder? sortOrder = SortOrder.Ascending)
        {
            return await GetEntities<Salary>(properties, orderBy, sortOrder);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Salary>> GetById(long Id)
        {
            return await GetEntity<Salary>(Id);
        }
        [HttpPut]
        public async Task<ActionResult<Salary>> Put(Salary salary)
        {
            return await PutEntity<Salary>(salary);
        }
        [HttpPatch("{Id}")]
        public async Task<ActionResult> Patch(long Id, [FromBody] JsonPatchDocument<Salary> patchDocument)
        {
            return await PatchEntity<Salary>(Id, patchDocument);
        }
        [HttpPost]
        public async Task<ActionResult<Salary>> Post(Salary salary)
        {
            return await PostEntity<Salary>(salary);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(long Id)
        {
            return await DeleteEntity<Salary>(Id);
        }

        [HttpGet("{SalaryId}/persons")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonsBySalary(long SalaryId)
        {
            return await GetEntitiesByForginKey<Person, PersonSalary>(p => p.SalaryId == SalaryId, p => p.Person);
        }
    }
}
