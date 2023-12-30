using Ebd.Mobile.Services.Interfaces;

namespace Ebd.Mobile
{
    public partial class App : Application
    {
        private readonly ILoggerService loggerService;

        public App(ILoggerService loggerService)
        {
            InitializeComponent();
            this.loggerService = loggerService;

            MainPage = new AppShell();

            if (Startup.ServiceProvider is null)
                throw new InvalidOperationException("ServiceProvider is not initialized.");
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
