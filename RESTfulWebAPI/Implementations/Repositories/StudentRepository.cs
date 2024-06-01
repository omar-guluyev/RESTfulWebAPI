using RESTfulWebAPI.Abstractions.Repositories;
using RESTfulWebAPI.Context;
using RESTfulWebAPI.Entities.ApplicationEntities;

namespace RESTfulWebAPI.Implementations.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(AppDBContext context) : base(context)
        {
        }
    }
}
