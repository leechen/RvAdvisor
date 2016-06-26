using System;
using System.Data.Entity;
using System.Linq;
using Advisor.Sdk;

namespace Advisor.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private IAdvisorDataContext context;
        private bool disposed;

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
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public TEntity Get<TEntity>(int id) where TEntity : Entity
        {
            TEntity entity = context.Set<TEntity>().Find(id);

            return entity == null || entity.IsDeleted ? null : entity;
        }

        public void Add<TEntity>(TEntity entity) where TEntity : Entity
        {
            context.Set<TEntity>().Add(entity);
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : Entity
        {
            DbSet<TEntity> dbSet = context.Set<TEntity>();
            if (context.GetEntryState(entity) == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);
        }

        public void SaveChanges()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                // log
                throw;
            }
        }
    }
}
