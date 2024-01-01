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
