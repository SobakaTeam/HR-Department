using HR_Department.APIv2.DBModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HR_Department.APIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : MyApiController
    {
        public PositionsController(AppDbContext context) : base(context)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Position>>> Get([FromQuery] Dictionary<string, string> properties,
            [FromHeader] string? orderBy, [FromHeader] SortOrder? sortOrder = SortOrder.Ascending)
        {
            return await GetEntities<Position>(properties, orderBy, sortOrder);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Position>> GetById(long Id)
        {
            return await GetEntity<Position>(Id);
        }
        [HttpPut]
        public async Task<ActionResult<Position>> Put(Position position)
        {
            return await PutEntity<Position>(position);
        }
        [HttpPatch("{Id}")]
        public async Task<ActionResult> Patch(long Id, [FromBody] JsonPatchDocument<Position> patchDocument)
        {
            return await PatchEntity<Position>(Id, patchDocument);
        }
        [HttpPost]
        public async Task<ActionResult<Position>> Post(Position position)
        {
            return await PostEntity<Position>(position);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(long Id)
        {
            return await DeleteEntity<Position>(Id);
        }

        [HttpGet("{PositionId}/persons")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonsByPosition(long PositionId)
        {
            return await GetEntitiesByForginKey<Person, PersonPosition>(p => p.PositionId == PositionId, p => p.Person);
        }
    }
}
