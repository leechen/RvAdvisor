using System;
using System.Data.Entity;
using Advisor.ObjectModel;

namespace Advisor.DataAccess
{
    public class AdvisorDbContext : DbContext, IAdvisorDataContext
    {
        public DbSet<RvPark> RvParks { get; set; }

        public virtual EntityState GetEntryState(object entity)
        {
            return Entry(entity).State;
        }
    }
}