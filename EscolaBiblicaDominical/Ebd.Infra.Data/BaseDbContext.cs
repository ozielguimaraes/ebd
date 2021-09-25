using Ebd.Infra.Data.Context.Interfaces;
using System.Data.Common;

namespace Ebd.Infra.Data
{
    public abstract class BaseDbContext : IDbContext
    {
        public BaseDbContext(DataBaseConfiguration dataBaseConfiguration)
        {
            DataBaseConfiguration = dataBaseConfiguration;
        }

        public DataBaseConfiguration DataBaseConfiguration { get; private set; }
        public abstract DbConnection Connection { get; }
        public abstract DbConnection GetDbConnectionOpen();
    }
}
