using Ebd.Mobile.Services.Interfaces;
using Plugin.FirebasePushNotification;

namespace Ebd.Mobile
{
    public partial class App : Application
    {
        private readonly ILoggerService loggerService;

        public App(ILoggerService loggerService)
        {
            InitializeComponent();
            this.loggerService = loggerService;

            //ConfigureFirebaseRefreshToken();
            MainPage = new AppShell();

            if (Startup.ServiceProvider is null)
                throw new InvalidOperationException("ServiceProvider is not initialized.");
        }

        private void ConfigureFirebaseRefreshToken()
        {
            CrossFirebasePushNotification.Current.Subscribe("all");
            CrossFirebasePushNotification.Current.OnTokenRefresh += OnFirebaseTokenRefresh;
        }

        private void OnFirebaseTokenRefresh(object source, FirebasePushNotificationTokenEventArgs args)
        {
            loggerService.LogInformation($"Firebase newToken: {args.Token}");
            //PushNotificationService.Current.SendRegistrationToServer(token: args.Token);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
