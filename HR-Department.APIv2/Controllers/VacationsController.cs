using HR_Department.APIv2.Controllers.BaseController;
using HR_Department.APIv2.DBModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HR_Department.APIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationsController : BaseEntityController
    {
        public VacationsController(AppDbContext context) : base(context)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vacation>>> Get([FromQuery] Dictionary<string, string> properties,
            [FromHeader] string? orderBy, [FromHeader] SortOrder? sortOrder = SortOrder.Ascending)
        {
            return await GetEntities<Vacation>(properties, orderBy, sortOrder);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Vacation>> GetById(long Id)
        {
            return await GetEntity<Vacation>(Id);
        }
        [HttpPut]
        public async Task<ActionResult<Vacation>> Put(Vacation vacation)
        {
            return await PutEntity<Vacation>(vacation);
        }
        [HttpPatch("{Id}")]
        public async Task<ActionResult> Patch(long Id, [FromBody] JsonPatchDocument<Vacation> patchDocument)
        {
            return await PatchEntity<Vacation>(Id, patchDocument);
        }
        [HttpPost]
        public async Task<ActionResult<Vacation>> Post(Vacation vacation)
        {
            return await PostEntity<Vacation>(vacation);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(long Id)
        {
            return await DeleteEntity<Vacation>(Id);
        }

        [HttpGet("{VacationId}/persons")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonsByVacation(long VacationId)
        {
            return await GetEntitiesByForginKey<Person, PersonVacation>(p => p.VacationId == VacationId, p => p.Person);
        }
    }
}
