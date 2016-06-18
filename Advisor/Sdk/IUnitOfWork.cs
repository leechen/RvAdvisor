using System;
using System.Linq;

namespace Advisor.Sdk
{
    public interface IUnitOfWork : IDisposable
    {
        IQueryable<TEntity> Get<TEntity>() where TEntity : Entity;

    }
}
