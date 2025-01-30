using HR_Department.APIv2.DBModels;
using HR_Department.APIv2.DBModels.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection;

namespace HR_Department.APIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly AppDbContext DBContext;

        public PersonsController(AppDbContext context)
        {
            DBContext = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons([FromQuery] Dictionary<string, string> properties,
            [FromHeader] string? orderBy, [FromHeader] SortOrder? sortOrder = SortOrder.Ascending)
        {
            IQueryable<Person> query = DBContext.Persons;
            //Property Filter
            if (properties != null)
            {
                foreach (var property in properties)
                {
                    query = ApplyFilter(query, property.Key, property.Value);
                }
            }
            //OrderBy Filter
            if (orderBy != null)
            {
                ApplyOrderBy(query, orderBy, sortOrder);
            }
            //Main Data Tamplate
            //query.Join(inner:DBContext.Authorizations,DBContext.PersonAuthorizations.Where();

            if (query != null )
            { return await query.ToListAsync(); }
            else
            { return NotFound(); }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetItemById(long id)
        {
            Person item = await DBContext.Persons.FirstOrDefaultAsync(p => p.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return item;
            }
        }


        private IQueryable<Person> ApplyFilter(IQueryable<Person> query, string propertyName, string value)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(Person), "p");
            MemberExpression property = Expression.Property(parameter, propertyName);

            // Check if the property exists and is not null
            if (property == null || property.Type == null)
            {
                return query; // Property does not exist or its Type is Null
            }

            // Get the underlying type of nullable types
            Type targetType = Nullable.GetUnderlyingType(property.Type) ?? property.Type;


            // Create the Constant expression
            var convertedValue = Convert.ChangeType(value, targetType);
            var constant = Expression.Constant(convertedValue, targetType);

            // Create the Equality expression
            var equalExpression = Expression.Equal(property, constant);
            // Create the Lambda Expression
            var lambda = Expression.Lambda<Func<Person, bool>>(equalExpression, parameter);

            return query.Where(lambda);
        }
        private IQueryable<Person> ApplyOrderBy(IQueryable<Person> query, string propertyName, SortOrder? sortOrder)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(Person), "p");
            MemberExpression property = Expression.Property(parameter, propertyName);

            if (property == null)
            {
                return query; // Property does not exist
            }
            if (sortOrder == SortOrder.Descending)
            {
                return query.OrderByDescending(Expression.Lambda<Func<Person, object>>(property, parameter));
            }
            else
            {
                return query.OrderBy(Expression.Lambda<Func<Person, object>>(property, parameter));
            }
        }
    }
}
