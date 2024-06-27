using RESTfulWebAPI.Abstractions.Repositories;
using RESTfulWebAPI.Entities.Common;

namespace RESTfulWebAPI.Abstractions.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        Task<int> SaveChangesAsync();
    }
}