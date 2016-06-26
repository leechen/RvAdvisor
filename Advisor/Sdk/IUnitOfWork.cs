using System;
using System.Linq;

namespace Advisor.Sdk
{
    public interface IUnitOfWork : IDisposable
    {
        IQueryable<TEntity> Get<TEntity>() where TEntity : Entity;
        TEntity Get<TEntity>(int id) where TEntity : Entity;
        void Add<TEntity>(TEntity entity) where TEntity : Entity;
        void Delete<TEntity>(TEntity entity) where TEntity : Entity;
        void SaveChanges();
    }
}
