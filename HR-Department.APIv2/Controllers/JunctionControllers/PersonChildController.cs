using HR_Department.APIv2.Controllers.BaseControllers;
using HR_Department.APIv2.DBModels;
using HR_Department.APIv2.DBModels.Types;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HR_Department.APIv2.Controllers.JunctionControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonChildController : BaseJunctionController
    {
        public PersonChildController(AppDbContext context) : base(context)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonChild>>> Get()
        {
            return await GetJunction<PersonChild>();
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<PersonChild>> GetById(long Id)
        {
            return await GetJunctionById<PersonChild>(Id);
        }
        [HttpPost]
        public async Task<ActionResult<PersonChild>> Post(long PersonId, long ChildId)
        {
            return await CreateJunction<PersonChild, Person, Child>(PersonId, ChildId);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(long Id)
        {
            return await DeleteJunction<PersonChild>(Id);
        }
    }
}
