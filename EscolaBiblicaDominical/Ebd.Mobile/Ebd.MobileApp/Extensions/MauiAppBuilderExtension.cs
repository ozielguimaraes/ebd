namespace Ebd.MobileApp.Extensions;

internal static class MauiAppBuilderExtension
{
    public static MauiAppBuilder ConfigureSentry(this MauiAppBuilder builder)
    {
        builder.UseSentry(options =>
        {
            options.Dsn = "https://58325106234031ed1a531b6cbcaf7d22@o4507538405916672.ingest.us.sentry.io/4507538408144896";


            // Use debug mode if you want to see what the SDK is doing.
            // Debug messages are written to stdout with Console.Writeline,
            // and are viewable in your IDE's debug console or with 'adb logcat', etc.
            // This option is not recommended when deploying your application.
            options.Debug = true;

            // Set TracesSampleRate to 1.0 to capture 100% of transactions for tracing.
            // We recommend adjusting this value in production.
            options.TracesSampleRate = 1.0;

            // Other Sentry options can be set here.
        });

        return builder;
    }
}
