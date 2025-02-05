using HR_Department.APIv2.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Json;
using System.Collections.Specialized;
using System.Composition.Convention;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection;

namespace HR_Department.APIv2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : MyApiController
    {
        public DepartmentsController(AppDbContext context) : base(context) 
        {
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments([FromQuery] Dictionary<string, string> properties, 
            [FromHeader] string? orderBy, [FromHeader] SortOrder? sortOrder = SortOrder.Ascending)
        {
            return await GetEntities<Department>(properties, orderBy, sortOrder);
        }
        [HttpGet("{departmentId}")]
        public async Task<ActionResult<Department>> GetDepartmentById(long departmentId)
        {
            return await GetEntity<Department>(departmentId);
        }
        [HttpPut]
        public async Task<ActionResult<Department>> PutDepartment(Department department)
        {
            return await PutEntity<Department>(department);
        }
        [HttpPatch("{departmentId}")]
        public async Task<ActionResult> PatchDepartment(long departmentId, [FromBody] JsonPatchDocument<Department> patchDocument)
        {
            return await PatchEntity<Department>(departmentId, patchDocument);
        }
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            return await PostEntity<Department>(department);
        }
        [HttpDelete("{departmentId}")]
        public async Task<ActionResult> DeleteDepartment(long departmentId)
        {
            return await DeleteEntity<Department>(departmentId);
        }

        [HttpGet("{departmentId}/persons")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonsByDepartment(long departmentId)
        {
            return await GetEntitiesByForginKey<Person,PersonDepartment>(p => p.DepartmentId == departmentId, p => p.Person);
        }
        [HttpGet("{departmentId}/organizations")]
        public async Task<ActionResult<IEnumerable<Organization>>> GetOrganizationsByDepartment(long departmentId)
        {
            return await GetEntitiesByForginKey<Organization, DepartmentOrganization>(e => e.DepartmentId == departmentId, e => e.Organization);
        }
    }
}
