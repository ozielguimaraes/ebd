using CommunityToolkit.Mvvm.Input;
using Ebd.Mobile.Services.Interfaces;
using Ebd.MobileApp.ViewModels.Home;

namespace Ebd.MobileApp.ViewModels;

internal sealed partial class WelcomePageViewModel : BasePageViewModel
{
    public WelcomePageViewModel(IDiagnosticService diagnosticService, IDialogService dialogService, ILoggerService logger) : base(diagnosticService, dialogService, logger)
    {
    }

    [RelayCommand]
    Task GetStarted() => Navigate<HomeViewModel>();
}