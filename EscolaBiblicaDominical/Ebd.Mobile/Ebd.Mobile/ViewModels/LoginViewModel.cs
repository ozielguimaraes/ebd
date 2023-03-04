using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Views;
using Xamarin.Forms;

namespace Ebd.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginViewModel(IDiagnosticService diagnosticService, IDialogService dialogService, ILoggerService logger)// : base(diagnosticService, dialogService, logger)
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            //Application.Current.MainPage = new AppShell();
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"{nameof(HomePage)}");
        }
    }
}
