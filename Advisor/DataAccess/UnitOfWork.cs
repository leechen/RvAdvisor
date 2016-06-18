using System;
using System.Linq;
using Advisor.Sdk;

namespace Advisor.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private IAdvisorDataContext context;

        public UnitOfWork()
            : this(new AdvisorDbContext())
        {

        }
        public UnitOfWork(IAdvisorDataContext context)
        {
            this.context = context;
        }
        public IQueryable<TEntity> Get<TEntity>() where TEntity : Entity
        {
            return context.Set<TEntity>().Where(e => !e.IsDeleted);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
