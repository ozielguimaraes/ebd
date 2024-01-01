using Ebd.Mobile.Repository;
using Ebd.Mobile.Services.Implementations;
using Ebd.Mobile.Services.Implementations.Diagnostic;
using Ebd.Mobile.Services.Implementations.Dialog;
using Ebd.Mobile.Services.Implementations.Logger;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.ViewModels;
using Ebd.Mobile.ViewModels.Aluno;
using Ebd.Mobile.ViewModels.Chamada;

namespace Ebd.Mobile
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            //services.AddSingleton<IApiService, ApiService>();
            services.AddSingleton<ILoggerService, LoggerService>();
            services.AddSingleton<IDiagnosticService, DiagnosticService>();
            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton<INetworkService, NetworkService>();
            services.AddSingleton(Connectivity.Current);

            services.AddSingleton<IAlunoService, AlunoService>();
            services.AddSingleton<IAvaliacaoService, AvaliacaoService>();
            services.AddSingleton<IBairroService, BairroService>();
            services.AddSingleton<ICepService, CepService>();
            services.AddSingleton<IChamadaService, ChamadaService>();
            services.AddSingleton<ILicaoService, LicaoService>();
            services.AddSingleton<IRevistaService, RevistaService>();
            services.AddSingleton<ISyncService, SyncService>();
            services.AddSingleton<ITurmaService, TurmaService>();

            return services;
        }

        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IRepository, Repository.Repository>();

            return services;
        }

        public static IServiceCollection ConfigureViewModels(this IServiceCollection services)
        {
            //ViewModels
            services.AddTransient<HomeViewModel>();
            services.AddTransient<ListaAlunoViewModel>();
            services.AddTransient<ItemsViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<NewItemViewModel>();
            services.AddTransient<ItemDetailViewModel>();
            services.AddTransient<AboutViewModel>();
            services.AddTransient<EfetuarChamadaViewModel>();
            services.AddTransient<EscolherTurmaViewModel>();
            services.AddTransient<NovoAlunoViewModel>();
            services.AddTransient<AdicionarResponsavelViewModel>();

            return services;
        }

        public static TService GetService<TService>() => Current.GetService<TService>();

        public static IServiceProvider Current =>
#if WINDOWS10_0_17763_0_OR_GREATER
        MauiWinUIApplication.Current.Services;
#elif ANDROID
            MauiApplication.Current.Services;
#elif IOS || MACCATALYST
        MauiUIApplicationDelegate.Current.Services;
#else
        null;
#endif
    }
}
