using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HR_Department.APIv2.DBModels;
using Microsoft.AspNetCore.JsonPatch;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using HR_Department.APIv2.Controllers.BaseController;

namespace HR_Department.APIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildrenController : MyApiController
    {
        public ChildrenController(AppDbContext context) : base(context)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Child>>> Get([FromQuery] Dictionary<string, string> properties,
            [FromHeader] string? orderBy, [FromHeader] SortOrder? sortOrder = SortOrder.Ascending)
        {
            return await GetEntities<Child>(properties, orderBy, sortOrder);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<Child>> GetById(long Id)
        {
            return await GetEntity<Child>(Id);
        }
        [HttpPut]
        public async Task<ActionResult<Child>> Put(Child child)
        {
            return await PutEntity<Child>(child);
        }
        [HttpPatch("{Id}")]
        public async Task<ActionResult> Patch(long Id, [FromBody] JsonPatchDocument<Child> patchDocument)
        {
            return await PatchEntity<Child>(Id, patchDocument);
        }
        [HttpPost]
        public async Task<ActionResult<Child>> Post(Child child)
        {
            return await PostEntity<Child>(child);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(long Id)
        {
            return await DeleteEntity<Child>(Id);
        }

        [HttpGet("{ChildId}/persons")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonsByChildren(long ChildId)
        {
            return await GetEntitiesByForginKey<Person, PersonChild>(p => p.ChildId == ChildId, p => p.Person);
        }
    }
}
