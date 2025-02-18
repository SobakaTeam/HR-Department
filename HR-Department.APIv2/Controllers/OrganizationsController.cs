using HR_Department.APIv2.Controllers.BaseController;
using HR_Department.APIv2.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HR_Department.APIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : MyApiController
    {
        public OrganizationsController(AppDbContext context) : base(context)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organization>>> Get([FromQuery] Dictionary<string, string> properties,
            [FromHeader] string? orderBy, [FromHeader] SortOrder? sortOrder = SortOrder.Ascending)
        {
            return await GetEntities<Organization>(properties, orderBy, sortOrder);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Organization>> GetById(long Id)
        {
            return await GetEntity<Organization>(Id);
        }
        [HttpPut]
        public async Task<ActionResult<Organization>> Put(Organization organization)
        {
            return await PutEntity<Organization>(organization);
        }
        [HttpPatch("{Id}")]
        public async Task<ActionResult> Patch(long Id, [FromBody] JsonPatchDocument<Organization> patchDocument)
        {
            return await PatchEntity<Organization>(Id, patchDocument);
        }
        [HttpPost]
        public async Task<ActionResult<Organization>> Post(Organization organization)
        {
            return await PostEntity<Organization>(organization);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(long Id)
        {
            return await DeleteEntity<Organization>(Id);
        }

        [HttpGet("{OrganizationId}/departments")]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartmentsByOrganization(long OrganizationId)
        {
            return await GetEntitiesByForginKey<Department, DepartmentOrganization>(e => e.OrganizationId == OrganizationId, e => e.Department);
        }
    }
}
