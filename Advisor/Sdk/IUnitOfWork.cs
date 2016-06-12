using System.Linq;

namespace Advisor.Sdk
{
    public interface IUnitOfWork
    {
        IQueryable<TEntity> Get<TEntity>() where TEntity : Entity;
    }
}
