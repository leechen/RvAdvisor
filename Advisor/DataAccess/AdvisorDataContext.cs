using System;
using System.Data.Entity;

namespace Advisor.DataAccess
{
    public class AdvisorDbContext : DbContext, IAdvisorDataContext
    {
        public virtual EntityState GetEntryState(object entity)
        {
            return Entry(entity).State;
        }
    }
}