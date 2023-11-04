using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Ebd.Infra.Data
{
    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MainContext>
    //{
    //    public MainContext CreateDbContext(string[] args)
    //    {
    //        IConfigurationRoot configuration = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json") // Adjust the configuration file name if it's different
    //            .Build();

    //        var builder = new DbContextOptionsBuilder<MainContext>();
    //        var connectionString = configuration.GetConnectionString("DefaultConnection");

    //        builder.UseNpgsql(connectionString);

    //        return new MainContext(new DataBaseConfiguration(connectionString));
    //    }
    //}
}
