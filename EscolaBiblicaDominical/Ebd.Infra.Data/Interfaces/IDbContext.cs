using System.Data.Common;

namespace Ebd.Infra.Data.Context.Interfaces
{
    public interface IDbContext
    {
        DataBaseConfiguration DataBaseConfiguration { get; }
        DbConnection Connection { get; }
        DbConnection GetDbConnectionOpen();
    }
}
