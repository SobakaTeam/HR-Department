using HR_Department.APIv2.DBModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Xml.XPath;

namespace HR_Department.APIv2.Controllers.BaseController
{
    public abstract class BaseEntityController : ControllerBase
    {
        protected readonly AppDbContext dbContext;
        public BaseEntityController(AppDbContext context)
        {
            dbContext = context;
        }
        //CRUD
        protected virtual async Task<ActionResult<IEnumerable<T>>> GetEntities<T>([FromQuery] Dictionary<string, string> properties,
            [FromHeader] string? orderBy, [FromHeader] SortOrder? sortOrder = SortOrder.Ascending) where T : class
        {
            IQueryable<T> query = dbContext.Set<T>();
            //Property Filter
            try
            {
                //Property Filter
                if (properties != null)
                {
                    foreach (var property in properties)
                    {
                        query = AplyWhereFilter(query, property.Key, property.Value);
                    }
                }
                //OrderBy Filter
                if (orderBy != null)
                {
                    query = AplyOrderBy(query, orderBy, sortOrder);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            //Main Data Tamplate
            //query.Join(inner:DBContext.Authorizations,DBContext.PersonAuthorizations.Where();

            if (query != null)
            { return await query.ToListAsync(); }
            else
            { return NotFound(); }
        }
        protected virtual async Task<ActionResult<T>> GetEntity<T>(long id) where T : class
        {
            var entity = await dbContext.Set<T>().FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }
            return entity;
        }
        protected virtual async Task<ActionResult<T>> PostEntity<T>(T entity) where T : class
        {
            if (entity == null)
            {
                return BadRequest();
            }
            //var validationResult = await _validator.ValidateAsync(person);

            //if (!validationResult.IsValid)
            //{
            //    return BadRequest(validationResult.Errors);
            //}
            try
            {
                dbContext.Set<T>().Add(entity);
                await dbContext.SaveChangesAsync();
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = "Error saving changes to database", Error = ex.Message });
            }
        }
        protected virtual async Task<ActionResult<T>> PutEntity<T>(T entity) where T : class
        {
            if (entity == null)
            {
                return BadRequest();
            }
            long entityId = GetId(entity);
            if (!await ExistsEntity<T>(entityId))
            {
                return NotFound();
            }
            try
            {
                dbContext.Set<T>().Entry(entity).State = EntityState.Modified;
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = "Error saving changes to database", Error = ex.Message });
            }
            return Ok(entity);
        }
        protected virtual async Task<ActionResult> PatchEntity<T>(long entityId, JsonPatchDocument<T> patchDocument) where T : class
        {
            var entity = await dbContext.Set<T>().FirstOrDefaultAsync(e => EF.Property<long>(e, "Id") == entityId);

            if (entity == null)
            {
                return NotFound();
            }
            try
            {
                patchDocument.ApplyTo(entity);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = "Error saving changes to database", Error = ex.Message });
            }
            return NoContent();
        }
        protected virtual async Task<ActionResult> DeleteEntity<T>(long id) where T : class
        {
            var entity = await dbContext.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            try
            {
                dbContext.Set<T>().Remove(entity);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = "Eror delete entity from database", Error = ex.Message });
            }
            return Ok();
        }
        protected virtual async Task<ActionResult<IEnumerable<T>>> GetEntitiesByForginKey<T, TForgin>(Expression<Func<TForgin, bool>> ForginKeyFilter, Expression<Func<TForgin, T>> entityPropertySelector)
            where TForgin : class
            where T : class
        {
            try
            {

                var entities = await dbContext.Set<TForgin>()
                    .Where(ForginKeyFilter)
                    .Select(entityPropertySelector)
                    .ToListAsync();
                if (!entities.Any())
                {
                    return NotFound();
                }
                return Ok(entities);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = "Error geting data from database", Error = ex.Message });
            }
        }
        //sub methods
        protected async Task<bool> ExistsEntity<T>(long id) where T : class
        {
            return await dbContext.Set<T>().AnyAsync(e => EF.Property<long>(e, "Id") == id);
        }
        protected IQueryable<T> AplyWhereFilter<T>(IQueryable<T> query, string propertyName, string value)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "p");
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
            var lambda = Expression.Lambda<Func<T, bool>>(equalExpression, parameter);

            return query.Where(lambda);
        }
        protected IQueryable<T> AplyOrderBy<T>(IQueryable<T> query, string propertyName, SortOrder? sortOrder)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "p");
            MemberExpression property = Expression.Property(parameter, propertyName);

            if (property == null)
            {
                return query; // Property does not exist
            }
            if (sortOrder == SortOrder.Descending)
            {
                return query.OrderByDescending(Expression.Lambda<Func<T, object>>(property, parameter));
            }
            else
            {
                return query.OrderBy(Expression.Lambda<Func<T, object>>(property, parameter));
            }
        }
        //local methods 
        private long GetId<T>(T entity) where T : class
        {
            var IdProperty = typeof(T).GetProperty("Id");
            if (IdProperty == null)
            {
                throw new InvalidOperationException("Entity must have a property called Id.");
            }
            return (long)IdProperty.GetValue(entity);
        }
        private object? GetPropertyValue<T>(T entity, string propertyName) where T : class
        {
            var property = typeof(T).GetProperty(propertyName);
            if (property == null)
            {
                throw new InvalidOperationException("Must have a property");
            }
            return property.GetValue(entity);
        }
    }
}
