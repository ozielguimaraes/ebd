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
            services.AddTransient(typeof(IBairroBusiness), typeof(BairroBusiness));
            services.AddTransient(typeof(IChamadaBusiness), typeof(ChamadaBusiness));
            services.AddTransient(typeof(ITurmaBusiness), typeof(TurmaBusiness));
            
            return services;
        }
    }
}
