using Ebd.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ebd.Infra.Data.Repositories
{
    public abstract class Repository<T> : IDisposable, IRepository<T> where T : class
    {
        protected MainContext Db;
        protected DbSet<T> DbSet;

        public Repository(MainContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public void Dispose()
        {
            DbSet = null;
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
