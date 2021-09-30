using Ebd.Application.Business.Implementation;
using Ebd.Application.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Ebd.CrossCutting.IoC
{
    public static class ApplicationConfigurationExtension
    {
        public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services)
        {
            services.AddTransient(typeof(IAlunoBusiness), typeof(AlunoBusiness));
            return services;
        }
    }
}
