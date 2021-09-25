using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Ebd.Infra.Data.Context.Interfaces
{
    public interface IEntityFrameworkContext
    {
        DataBaseConfiguration Configuration { get; }
        //DbSet<TEntity> Set<TEntity>() where TEntity : class;
        //EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        //int SaveChanges();
        DatabaseFacade GetDatabase();
        void Dispose();
    }
}