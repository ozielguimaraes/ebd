using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ebd.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IBairroService _bairroService;

        public Command LoginCommand { get; }

        public LoginViewModel(IDiagnosticService diagnosticService, IDialogService dialogService, ILoggerService loggerService) : base(diagnosticService, dialogService, loggerService)
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            //Application.Current.MainPage = new AppShell();
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"{nameof(HomePage)}");
        }

        private async Task SyncData()
        {
            Task.Factory.StartNew(() =>
            {

            });
        }
    }
}
