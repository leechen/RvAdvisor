﻿using System;
using System.Data.Entity;

namespace Advisor.DataAccess
{
    public interface IAdvisorDataContext : IDisposable
    {
        EntityState GetEntryState(object entity);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}
