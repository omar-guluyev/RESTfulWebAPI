using RESTfulWebAPI.Abstractions.Repositories;
using RESTfulWebAPI.Context;
using RESTfulWebAPI.Entities.ApplicationEntities;

namespace RESTfulWebAPI.Implementations.Repositories
{
    public class SchoolRepository : Repository<School>, ISchoolRepository
    {
        public SchoolRepository(AppDBContext context) : base(context)
        {
        }
    }
}
