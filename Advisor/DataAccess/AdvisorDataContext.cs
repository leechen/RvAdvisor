using System;
using System.Data.Entity;

namespace Advisor.DataAccess
{
    internal class AdvisorDbContext : DbContext, IAdvisorDataContext
    {
        public virtual EntityState GetEntryState(object entity)
        {
            return Entry(entity).State;
        }
    }
}