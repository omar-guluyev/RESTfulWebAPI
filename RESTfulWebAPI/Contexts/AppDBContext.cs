using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RESTfulWebAPI.Entities.ApplicationEntities;
using RESTfulWebAPI.Entities.Identity;

namespace RESTfulWebAPI.Context
{
    public class AppDBContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
