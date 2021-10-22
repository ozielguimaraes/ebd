using Ebd.Mobile.Services;
using Ebd.Mobile.Views;
using Ebd.Mobile.Views.Aluno;
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
            Routing.RegisterRoute(nameof(ListaAlunoPage), typeof(ListaAlunoPage));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
