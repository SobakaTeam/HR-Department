using HR_Department.APIv2.Controllers.BaseControllers;
using HR_Department.APIv2.DBModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HR_Department.APIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationsController : BaseEntityController
    {
        public AuthorizationsController(AppDbContext context) : base(context)
        {
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Authorization>>> Get([FromQuery] Dictionary<string, string> properties,
            [FromHeader] string? orderBy, [FromHeader] SortOrder? sortOrder = SortOrder.Ascending)
        {
            return await GetEntities<Authorization>(properties, orderBy, sortOrder);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Authorization>> GetById(long Id)
        {
            return await GetEntity<Authorization>(Id);
        }
        [HttpPut]
        public async Task<ActionResult<Authorization>> Put(Authorization authorization)
        {
            return await PutEntity<Authorization>(authorization);
        }
        [HttpPatch("{Id}")]
        public async Task<ActionResult> Patch(long Id, [FromBody] JsonPatchDocument<Authorization> patchDocument)
        {
            return await PatchEntity<Authorization>(Id, patchDocument);
        }
        [HttpPost]
        public async Task<ActionResult<Authorization>> Post(Authorization authorization)
        {
            return await PostEntity<Authorization>(authorization);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(long Id)
        {
            return await DeleteEntity<Authorization>(Id);
        }

        [HttpGet("{AuthorizationId}/persons")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonsByAuthorization(long AuthorizationId)
        {
            return await GetEntitiesByForginKey<Person, PersonAuthorization>(p => p.AuthorizationId == AuthorizationId, p => p.Person);
        }
    }
}
