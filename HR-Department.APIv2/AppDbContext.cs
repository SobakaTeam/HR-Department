using HR_Department.APIv2.Models.DBModels.Persons;
using Microsoft.EntityFrameworkCore;

namespace HR_Department.APIv2
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Person>  People { get; set; }
    }
}
