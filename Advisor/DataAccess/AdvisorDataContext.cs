using System;
using System.Data.Entity;
using Advisor.ObjectModel;
using Advisor.Sdk;

namespace Advisor.DataAccess
{
    public class AdvisorDbContext : DbContext, IAdvisorDataContext
    {
        public DbSet<RvPark> RvParks { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Area> Areas { get; set; }

        public virtual EntityState GetEntryState(object entity)
        {
            return Entry(entity).State;
        }

        public override int SaveChanges()
        {
            DateTime now = DateTime.UtcNow;

            foreach(var entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = now;
                        goto case EntityState.Modified;
                    case EntityState.Modified:
                        entry.Entity.LastUpdated = now;
                        break;
                }
            }

            return base.SaveChanges();
        }
    }
}