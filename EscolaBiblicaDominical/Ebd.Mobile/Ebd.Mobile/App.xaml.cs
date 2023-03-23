using Ebd.Mobile.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Plugin.FirebasePushNotification;
using Xamarin.Forms;

namespace Ebd.Mobile
{
    public partial class App : Application
    {
        private readonly ILoggerService loggerService;

        public App()
        {
            InitializeComponent();
            Startup.Init();
            //ConfigureFirebaseRefreshToken();
            MainPage = new AppShell();
            loggerService = Startup.ServiceProvider.GetService<ILoggerService>();
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
