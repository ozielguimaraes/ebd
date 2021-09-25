using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Ebd.CrossCutting.IoC
{
    internal static class IConfigurationExtension
    {
        public static T GetConfiguration<T>(this IConfiguration configuration) where T : class, new()
        {
            T config = new();
            new ConfigureFromConfigurationOptions<T>(configuration.GetSection(typeof(T).Name)).Configure(config);
            return config;
        }
    }
}
