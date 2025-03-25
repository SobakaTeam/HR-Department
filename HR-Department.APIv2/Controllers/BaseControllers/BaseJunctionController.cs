using HR_Department.APIv2.DBModels;
using HR_Department.APIv2.DBModels.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HR_Department.APIv2.Controllers.BaseControllers
{
    public class BaseJunctionController : ControllerBase
    {
        protected readonly AppDbContext dbContext;
        public BaseJunctionController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        protected async Task<ActionResult<IEnumerable<TJunction>>> GetJunction<TJunction>()
            where TJunction : class
        {
            return Ok(await dbContext.Set<TJunction>().ToListAsync());
        }
        protected async Task<ActionResult<TJunction>> GetJunctionById<TJunction>(long Id)
            where TJunction : class
        {
            try
            {
                var junctionObj = await dbContext.Set<TJunction>().FindAsync(Id);
                if (junctionObj == null)
                {
                    return NotFound();
                }
                return Ok(junctionObj);
            }
            catch (Exception ex)
            {
                throw new Exception($"Возникло исключение в попытке выборки из таблицы", ex);
            }
        }
        protected async Task<ActionResult<TJunction>> CreateJunction<TJunction, TEntity1, TEntity2>(long entity1Id, long entity2Id)
            where TJunction : class
            where TEntity1 : class
            where TEntity2 : class
        {
            string entity1Name = typeof(TEntity1).Name;
            string entity2Name = typeof(TEntity2).Name;

            //проверка на существование метода добавления 
            if (dbContext.Set<TJunction>().GetType().GetMethod("Add") == null)
            {
                return BadRequest($"Не удалось найти метод 'Add' в {typeof(TJunction).Name}");
            }
            //проверка на существующие ID связуемых сущностей
            if (!await dbContext.Set<TEntity1>().AnyAsync(e => EF.Property<long>(e, "Id").Equals(entity1Id)))
            {
                return BadRequest($"Сущность типа {typeof(TEntity1).Name} с ID {entity1Id} не найдена.");
            }
            if (!await dbContext.Set<TEntity2>().AnyAsync(e => EF.Property<long>(e, "Id").Equals(entity2Id)))
            {
                return BadRequest($"Сущность типа {typeof(TEntity2).Name} с ID {entity2Id} не найдена");
            }
            //получение свойств связующей таблицы
            string seperator = "_ID";
            PropertyInfo junctionProp1 = typeof(TJunction).GetProperty(entity1Name + seperator);
            PropertyInfo junctionProp2 = typeof(TJunction).GetProperty(entity2Name + seperator);
            if (junctionProp1 == null)
            {
                return BadRequest($"Не удалось найти свойсвто {entity1Name} в типе {typeof(TJunction).Name}");
            }
            if (junctionProp2 == null)
            {
                return BadRequest($"Не удалось найти свойсвто {entity2Name} в типе {typeof(TJunction).Name}");
            }
            //установка новых значений
            try
            {
                //новый обьект
                TJunction junctinObject = Activator.CreateInstance<TJunction>();
                junctionProp1.SetValue(junctinObject, entity1Id);
                junctionProp2.SetValue(junctinObject, entity2Id);

                dbContext.Set<TJunction>().Add(junctinObject);
                await dbContext.SaveChangesAsync();
                return Ok(junctinObject);
            }
            catch (Exception ex)
            {
                throw new Exception($"Возникло исключение в попытке добавление нового обьекта в связующую таблицу", ex);
            }
        }
        protected async Task<ActionResult> DeleteJunction<TJunction>(long junctionId)
            where TJunction : class
        {
            //проверка на существование метода remove 
            if (dbContext.Set<TJunction>().GetType().GetMethod("Remove") == null)
            {
                return BadRequest($"Не удалось найти метод 'Remove' в {typeof(TJunction).Name}");
            }
            try
            {
                var junctionObj = await dbContext.Set<TJunction>().FindAsync(junctionId);
                dbContext.Set<TJunction>().Remove(junctionObj);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception($"Возникло исключение в попытке удаления обьекта в связующей таблице", ex);
            }
        }
    }
}
