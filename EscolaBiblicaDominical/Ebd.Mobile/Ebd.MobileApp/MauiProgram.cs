using CommunityToolkit.Maui;
using Controls.UserDialogs.Maui;
using Microsoft.Extensions.Logging;
using The49.Maui.BottomSheet;

namespace Ebd.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseUserDialogs()
            .UseBottomSheet()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSansRegular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSansMedium.ttf", "OpenSansMedium");
                fonts.AddFont("OpenSansBold.ttf", "OpenSansBold");
                fonts.AddFont("fa-solid-900.ttf", "FontAwesome");
            })
            .UseMauiCommunityToolkit();

#if ANDROID
        builder.Services.AddSingleton(UserDialogs.Instance);
#endif

        builder.Services
            .ConfigureAndHandleHttpClient()
            .ConfigureServices()
            .ConfigureRepositories()
            .ConfigureViewModels()
            .ConfigurePages()
            .BuildServiceProvider();
#if DEBUG
        builder.Logging.AddDebug();
        AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
        {
            if (e.ExceptionObject is Exception ex)
            {
                //SentrySdk.CaptureException(ex);
            }
        };

        TaskScheduler.UnobservedTaskException += (sender, e) =>
        {
            //SentrySdk.CaptureException(e.Exception);
            e.SetObserved();
        };
#endif
        var app = builder.Build();
        DependencyInjection.Initialize(app.Services);

        return app;
    }
}
