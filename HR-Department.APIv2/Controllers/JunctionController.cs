using HR_Department.APIv2.Controllers.BaseController;
using HR_Department.APIv2.DBModels;
using HR_Department.APIv2.DBModels.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using System.Reflection;

namespace HR_Department.APIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JunctionController : BaseJunctionController
    {
        public JunctionController(AppDbContext dbContext) : base(dbContext)
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IJunction>>> Get(string junctionName) // тута много работа
        {
            string typePath = $"HR_Department.APIv2.DBModels.{junctionName}";
            Type junctionType  = Type.GetType(typePath);
            if(junctionType == null)
            {
                return BadRequest($"Not found type {junctionName}");
            }
            var getMethod = typeof(BaseJunctionController).GetMethod()
            if (getMethod == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var getJunction = getMethod.MakeGenericMethod(junctionType);
            dynamic list = getJunction.Invoke(null,null);
            return await list;
        }
    }
}
