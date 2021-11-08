using Ebd.Mobile.Services.Interfaces;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ebd.Mobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel(IDiagnosticService diagnosticService, IDialogService dialogService, ILoggerService logger) //: base(diagnosticService, dialogService, logger)
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}