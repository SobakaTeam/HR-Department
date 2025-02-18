using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System.Linq.Expressions;

namespace HR_Department.APIv2.Controllers.BaseController
{
    public interface IBaseEntityController
    {
        public Task<ActionResult<IEnumerable<T>>> GetEntities<T>([FromQuery] Dictionary<string, string> properties,
            [FromHeader] string? orderBy, [FromHeader] SortOrder? sortOrder = SortOrder.Ascending) where T : class;

        public Task<ActionResult<T>> GetEntity<T>(long id) where T : class;

        protected Task<ActionResult<T>> PostEntity<T>(T entity) where T : class;
        protected Task<ActionResult<T>> PutEntity<T>(T entity) where T : class;
        protected Task<ActionResult> PatchEntity<T>(long entityId, JsonPatchDocument<T> patchDocument) where T : class;
        protected Task<ActionResult> DeleteEntity<T>(long id) where T : class;
        protected Task<ActionResult<IEnumerable<T>>> GetEntitiesByForginKey<T, TForgin>(Expression<Func<TForgin, bool>> ForginKeyFilter, Expression<Func<TForgin, T>> entityPropertySelector)
            where TForgin : class
            where T : class;

    }
}
