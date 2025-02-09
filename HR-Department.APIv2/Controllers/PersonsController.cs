using HR_Department.APIv2.DBModels;
using HR_Department.APIv2.DBModels.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Numerics;
using System.Reflection;

namespace HR_Department.APIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : MyApiController
    {
        public PersonsController(AppDbContext context) : base(context) 
        {
            //there i set DB context to perents class into "dbContext"
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons([FromQuery] Dictionary<string, string> properties,
            [FromHeader] string? orderBy, [FromHeader] SortOrder? sortOrder = SortOrder.Ascending)
        {
            return await GetEntities<Person>(properties, orderBy, sortOrder);
        }
        [HttpGet("{personId}")]
        public async Task<ActionResult<Person>> GetPersonById(long personId)
        {
            return await GetEntity<Person>(personId);
        }
        [HttpPut]
        public async Task<ActionResult<Person>> PutPerson(Person person)
        {
            return await PutEntity<Person>(person);
        }
        [HttpPatch("{personId}")]
        public async Task<IActionResult> PatchPerson(long personId, [FromBody] JsonPatchDocument<Person> patchDocument)
        {
            return await PatchEntity<Person>(personId, patchDocument);
        }
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(PersonDTO personDTO)
        {
            if (personDTO == null)
            {
                return BadRequest();
            }
            Person person = new Person();
            foreach (var propety in typeof(PersonDTO).GetProperties())
            {
                person.GetType().GetProperty(propety.Name).SetValue(person,propety.GetValue(personDTO));
            }

            return await PostEntity<Person>(person);
        }
        [HttpDelete("{personId}")]
        public async Task<ActionResult> DeletePerson(long personId)
        {
            return await DeleteEntity<Person>(personId);
        }
        [HttpGet("{personId}/departments")]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartmentsByPersonId(long personId)
        {
           return await GetEntitiesByForginKey<Department,PersonDepartment>(pd => pd.PersonId == personId, pd => pd.Department);
        }
        [HttpGet("{personId}/positions")]
        public async Task<ActionResult<IEnumerable<Position>>> GetPositionsByPersonId(long personId)
        {
            return await GetEntitiesByForginKey<Position,PersonPosition>(p=>p.PersonId == personId, p => p.Position);

        }
        [HttpGet("{personId}/children")]
        public async Task<ActionResult<IEnumerable<Child>>> GetChildrenByPersonId(long personId)
        {
            return await GetEntitiesByForginKey<Child,PersonChild>(e=>e.PersonId == personId, e => e.Child);

        }
        [HttpGet("{personId}/vacations")]
        public async Task<ActionResult<IEnumerable<Vacation>>> GetVacationsByPersonId(long personId)
        {
            return await GetEntitiesByForginKey<Vacation, PersonVacation>(e => e.PersonId == personId, e => e.Vacation);

        }
        [HttpGet("{personId}/salaries")]
        public async Task<ActionResult<IEnumerable<Salary>>> GetSalariesByPersonId(long personId)
        {
            return await GetEntitiesByForginKey<Salary, PersonSalary>(e => e.PersonId == personId, e => e.Salary);
        }

        //Sub Methods
        private bool PersonExists(long id)
        {
            return dbContext.Persons.Any(e => e.Id == id);
        }
    }
}
