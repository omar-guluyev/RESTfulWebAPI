using RESTfulWebAPI.Abstractions.Repositories;
using RESTfulWebAPI.Abstractions.UnitOfWork;
using RESTfulWebAPI.Context;
using RESTfulWebAPI.Entities.ApplicationEntities;
using RESTfulWebAPI.Entities.Common;
using RESTfulWebAPI.Implementations.Repositories;

namespace RESTfulWebAPI.Implementations.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext context;
        private Dictionary<Type, object> repositories;
        public UnitOfWork(AppDBContext context)
        {
            this.context = context;
            repositories = new Dictionary<Type, object>();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            if (repositories.ContainsKey(typeof(T)))
            {
                return (IRepository<T>)repositories[typeof(T)];
            }

            IRepository<T> repository = new Repository<T>(context);
            repositories.Add(typeof(T), repository);
            return repository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
