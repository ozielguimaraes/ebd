using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ebd.Presentation.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
        }

        public static IHostBuilder ConfigureAppSettings(this IHostBuilder host)
        {
            host.ConfigureAppConfiguration((ctx, builder) =>
            {
                builder.AddJsonFile("appsettings.json", false, true);
                builder.AddEnvironmentVariables();
            });

            return host;
        }
    }
}
