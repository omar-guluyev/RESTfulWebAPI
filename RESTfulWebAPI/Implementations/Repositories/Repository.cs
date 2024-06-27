using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RESTfulWebAPI.Abstractions.Repositories;
using RESTfulWebAPI.Context;
using RESTfulWebAPI.Entities.Common;

namespace RESTfulWebAPI.Implementations.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDBContext context;

        public Repository(AppDBContext context)
        {
            this.context = context;
        }
        public DbSet<T> Table => context.Set<T>();

        public async Task<bool> AddAsync(T data)
        {
            EntityEntry entity = await Table.AddAsync(data);
            return entity.State == EntityState.Added;
        }

        public IQueryable<T> GetAll()
        {
            var query = Table.AsQueryable();
            return query;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var query = Table.AsQueryable();
            return await query.FirstOrDefaultAsync(Data => Data.Id == id);
        }

        public bool Remove(T data)
        {
            var entity = Table.Remove(data);
            return entity.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveById(int id)
        {
            T data = await Table.FindAsync(id);
            return Remove(data);
        }

        public bool Update(T data)
        {
            var entity = Table.Update(data);
            return entity.State == EntityState.Modified;
        }
    }
}
