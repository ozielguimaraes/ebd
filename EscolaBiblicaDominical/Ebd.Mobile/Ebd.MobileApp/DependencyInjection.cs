using CommunityToolkit.Maui;
using Ebd.Mobile.Repository;
using Ebd.Mobile.Services.Implementations;
using Ebd.Mobile.Services.Implementations.Diagnostic;
using Ebd.Mobile.Services.Implementations.Dialog;
using Ebd.Mobile.Services.Implementations.Logger;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.ViewModels;
using Ebd.Mobile.ViewModels.Aluno;
using Ebd.Mobile.ViewModels.Chamada;
using Ebd.Mobile.Views;
using Ebd.Mobile.Views.Aluno;
using Ebd.Mobile.Views.Chamada;
using Ebd.MobileApp.Network;
using Ebd.MobileApp.Services.Implementations;
using Ebd.MobileApp.Services.Implementations.Analytics;
using Ebd.MobileApp.Services.Implementations.BottomSheets;
using Ebd.MobileApp.Services.Interfaces.BottomSheets;
using Ebd.MobileApp.ViewModels.Home;
using Ebd.MobileApp.ViewModels.Perfil;
using Ebd.MobileApp.ViewModels.Turma;
using Ebd.MobileApp.ViewModels.Welcome;
using Ebd.MobileApp.Views.Perfil;
using Ebd.MobileApp.Views.Welcome;

namespace Ebd.Mobile;

public static class DependencyInjection
{
    public static IServiceProvider? Services { get; private set; }

    public static IServiceCollection ConfigureAndHandleHttpClient(this IServiceCollection services)
    {
        //            services.AddSingleton<IPlatformHttpMessageHandler>(_ =>
        //            {
        //#if ANDROID
        //                return new Ebd.MobileApp.Platforms.Android.Network.AndroidHttpMessageHandler();
        //#elif IOS
        //                return new MobileApp.Platforms.iOS.Network.IosHttpMessageHandler();
        //#endif
        //            });
        services.AddHttpClient("maui-to-https-localhost", httpClient =>
        {
            var baseAddress = DynamicBaseUrl.GetAdjustedBaseUrl();

            httpClient.BaseAddress = new Uri(baseAddress);
        })
            .ConfigureHttpMessageHandlerBuilder(builder =>
            {
                var platfromHttpMessageHandler = builder.Services.GetRequiredService<IPlatformHttpMessageHandler>();
                builder.PrimaryHandler = platfromHttpMessageHandler.GetHttpMessageHandler();
            });

        return services;
    }

    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddSingleton<IConfiguracoesDoUsuarioService, ConfiguracoesDoUsuarioService>();
        services.AddSingleton<IPreferences>(Preferences.Default);

        //services.AddSingleton<IApiService, ApiService>();
        services.AddSingleton<ILoggerService, LoggerService>();
        services.AddSingleton<IDiagnosticService, DiagnosticService>();
        services.AddSingleton<IAnalyticsService, AnalyticsService>();
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
        services.AddSingleton<IUsuarioService, UsuarioService>();

        //BottomSheets
        services.AddSingleton<IEscolherTurmaBottomSheetService, EscolherTurmaBottomSheetService>();

        return services;
    }

    public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IRepository, Repository.Repository>();

        return services;
    }

    public static IServiceCollection ConfigurePages(this IServiceCollection services)
    {
        services.AddTransient<WelcomePage>();
        services.AddTransient<HomePage>();
        services.AddTransient<ListaAlunoPage>();
        services.AddTransient<ItemsPage>();
        services.AddTransient<LoginPage>();
        services.AddTransient<NewItemPage>();
        services.AddTransient<ItemDetailPage>();
        services.AddTransient<AboutPage>();
        services.AddTransient<EfetuarChamadaPage>();
        services.AddTransient<EscolherTurmaPage>();
        services.AddTransient<NovoAlunoPage>();
        services.AddTransient<AdicionarResponsavelPage>();
        services.AddTransient<PerfilPage>();

        return services;
    }

    public static IServiceCollection ConfigureViewModels(this IServiceCollection services)
    {
        services.AddTransient<WelcomeViewModel>();
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

        //Perfil
        services.AddTransient<PerfilPageViewModel>();

        //BottomSheets
        services.AddTransient<EscolherTurmaBottomSheetViewModel>();

        return services;
    }

    public static TService GetService<TService>()
    {
        var instance = Services!.GetService<TService>();

        return instance ?? throw new ArgumentNullException("Service não registrado");
    }

    public static void Initialize(IServiceProvider serviceProvider) => Services = serviceProvider;

    internal static T GetByType<T>(Type type)
    {
        var instance = Services!.GetService(type);

        if (instance is T instanceT)
            return instanceT;

        throw new ArgumentNullException("Serviço não registrado");
    }
}
