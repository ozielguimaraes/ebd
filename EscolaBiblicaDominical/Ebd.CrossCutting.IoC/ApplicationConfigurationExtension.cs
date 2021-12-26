using Ebd.Application.Business.Implementation;
using Ebd.Application.Business.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Ebd.CrossCutting.IoC
{
    public static class ApplicationConfigurationExtension
    {
        public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAlunoBusiness), typeof(AlunoBusiness));
            services.AddScoped(typeof(IAvaliacaoBusiness), typeof(AvaliacaoBusiness));
            services.AddScoped(typeof(IAvaliacaoAlunoBusiness), typeof(AvaliacaoAlunoBusiness));
            services.AddScoped(typeof(IBairroBusiness), typeof(BairroBusiness));
            services.AddScoped(typeof(IChamadaBusiness), typeof(ChamadaBusiness));
            services.AddScoped(typeof(ILicaoBusiness), typeof(LicaoBusiness));
            services.AddScoped(typeof(ITurmaBusiness), typeof(TurmaBusiness));
            services.AddScoped(typeof(IRevistaBusiness), typeof(RevistaBusiness)); 
            
            return services;
        }
    }
}
