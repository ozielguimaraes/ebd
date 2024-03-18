using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.ViewModels;

namespace Ebd.MobileApp.ViewModels;

internal abstract partial class BasePageViewModel : BaseViewModel
{
    protected BasePageViewModel(IDiagnosticService diagnosticService, IDialogService dialogService, ILoggerService logger) : base(diagnosticService, dialogService, logger)
    {
    }

    public virtual Task Initialize(object? parameter = null) => Task.CompletedTask;
}