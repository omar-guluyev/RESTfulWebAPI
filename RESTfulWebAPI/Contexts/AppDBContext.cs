using Microsoft.EntityFrameworkCore;
using RESTfulWebAPI.Entities.ApplicationEntities;

namespace RESTfulWebAPI.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
