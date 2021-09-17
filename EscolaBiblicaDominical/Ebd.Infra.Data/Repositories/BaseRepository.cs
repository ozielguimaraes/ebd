using Ebd.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ebd.Infra.Data.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected MainContext Db;
        protected DbSet<T> DbSet;

        public BaseRepository(MainContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }
    }
}
