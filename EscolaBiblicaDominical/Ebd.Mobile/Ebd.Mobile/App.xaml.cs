using Ebd.Mobile.Services;
using Ebd.Mobile.Views;
using Xamarin.Forms;

namespace Ebd.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
