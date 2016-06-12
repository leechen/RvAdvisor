using System;
using System.Linq;
using Advisor.Sdk;

namespace Advisor.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public IQueryable<TEntity> Get<TEntity>() where TEntity : Entity
        {
            throw new NotImplementedException();
        }
    }
}
