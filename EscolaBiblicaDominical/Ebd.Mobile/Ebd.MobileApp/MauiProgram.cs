using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace Ebd.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSansRegular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSansMedium.ttf", "OpenSansMedium");
                fonts.AddFont("OpenSansBold.ttf", "OpenSansBold");
            })
            .UseMauiCommunityToolkit();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}
