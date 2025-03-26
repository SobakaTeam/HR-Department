using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HR_Department.APIv2.DBModels;
using HR_Department.APIv2.Controllers.BaseControllers;

namespace HR_Department.APIv2.Controllers.JunctionControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonPositionController : BaseJunctionController
    {   
        public PersonPositionController(AppDbContext context) : base(context)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonPosition>>> Get()
        {
            return await GetJunction<PersonPosition>();
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<PersonPosition>> GetById(long Id)
        {
            return await GetJunctionById<PersonPosition>(Id);
        }
        [HttpPost]
        public async Task<ActionResult<PersonPosition>> Post(long PersonId, long PositionId)
        {
            return await CreateJunction<PersonPosition, Person, Position>(PersonId, PositionId);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(long Id)
        {
            return await DeleteJunction<PersonPosition>(Id);
        }



    }
}
