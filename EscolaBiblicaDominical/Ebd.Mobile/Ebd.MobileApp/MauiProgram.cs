using CommunityToolkit.Maui;

namespace Ebd.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiCommunityToolkit()
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSansRegular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSansSemibold.ttf", "OpenSansSemibold");
            });

        return builder.Build();
    }
}
