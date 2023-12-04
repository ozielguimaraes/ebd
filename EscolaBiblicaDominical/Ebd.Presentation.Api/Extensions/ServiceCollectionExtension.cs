using Microsoft.Extensions.DependencyInjection;

namespace Ebd.Presentation.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
        }
    }
}
