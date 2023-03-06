using Ebd.Mobile.Services;
using Ebd.Mobile.Services.Implementations;
using Ebd.Mobile.Services.Implementations.Diagnostic;
using Ebd.Mobile.Services.Implementations.Dialog;
using Ebd.Mobile.Services.Implementations.Logger;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.ViewModels;
using Ebd.Mobile.ViewModels.Aluno;
using Ebd.Mobile.ViewModels.Chamada;
using Plugin.FirebasePushNotification;
using Xamarin.Forms;

namespace Ebd.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            RegisterDependencies();
            //ConfigureFirebaseRefreshToken();
            MainPage = new AppShell();
        }

        private void ConfigureFirebaseRefreshToken()
        {
            CrossFirebasePushNotification.Current.Subscribe("all");
            CrossFirebasePushNotification.Current.OnTokenRefresh += OnFirebaseTokenRefresh;
        }

        private void OnFirebaseTokenRefresh(object source, FirebasePushNotificationTokenEventArgs args)
        {
            LoggerService.Current.LogInformation($"Firebase newToken: {args.Token}");
            //PushNotificationService.Current.SendRegistrationToServer(token: args.Token);
        }

        private static void RegisterDependencies()
        {
            DependencyService.Register<MockDataStore>();
            //Services
            DependencyService.Register<ILoggerService, LoggerService>();
            DependencyService.Register<IDiagnosticService, DiagnosticService>();
            DependencyService.Register<IDialogService, DialogService>();
            DependencyService.Register<INetworkService, NetworkService>();

            DependencyService.Register<IAlunoService, AlunoService>();
            DependencyService.Register<IAvaliacaoService, AvaliacaoService>();
            DependencyService.Register<IChamadaService, ChamadaService>();
            DependencyService.Register<ITurmaService, TurmaService>();
            DependencyService.Register<IRevistaService, RevistaService>();
            DependencyService.Register<ILicaoService, LicaoService>();

            //ViewModels
            DependencyService.Register<HomeViewModel>();
            DependencyService.Register<ListaAlunoViewModel>();
            DependencyService.Register<ItemsViewModel>();
            DependencyService.Register<LoginViewModel>();
            DependencyService.Register<NewItemViewModel>();
            DependencyService.Register<ItemDetailViewModel>();
            DependencyService.Register<AboutViewModel>();
            DependencyService.Register<EfetuarChamadaViewModel>();
            DependencyService.Register<EscolherTurmaViewModel>();
            DependencyService.Register<NovoAlunoViewModel>();
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
