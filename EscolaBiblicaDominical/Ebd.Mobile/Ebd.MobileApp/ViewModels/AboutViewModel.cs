using Ebd.Mobile.Services.Interfaces;
using System.Windows.Input;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace Ebd.Mobile.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel(IDiagnosticService diagnosticService, IDialogService dialogService, ILoggerService loggerService) : base(diagnosticService, dialogService, loggerService)
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}