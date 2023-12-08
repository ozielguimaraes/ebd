using Android.App;
using Android.OS;
using Android.Runtime;
using Ebd.Mobile.Services.Implementations.Logger;
using Plugin.FirebasePushNotification;
using System;

namespace Ebd.Mobile.Droid
{
    [Application]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            //Set the default notification channel for your app when running Android Oreo
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                //Change for your default notification channel id here
                FirebasePushNotificationManager.DefaultNotificationChannelId = "com.companyname.ebd.mobile.notification";

                //Change for your default notification channel name here
                FirebasePushNotificationManager.DefaultNotificationChannelName = "Geral";

                FirebasePushNotificationManager.DefaultNotificationChannelImportance = NotificationImportance.Max;
            }

            //If debug you should reset the token each time.
#if DEBUG
            //FirebasePushNotificationManager.Initialize(this, true);
#else
            //FirebasePushNotificationManager.Initialize(this, false);
#endif

            //Handle notification when app is closed here
            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
                var loggerService = new LoggerService();
                loggerService.LogInformation($"data count: {p.Data.Count}");
                loggerService.LogInformation($"title: {p.Data["title"]}");
                loggerService.LogInformation($"body: {p.Data["body"]}");
            };
        }
    }
}