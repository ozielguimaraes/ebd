using Ebd.Mobile.Extensions;
using Ebd.Mobile.Services.Interfaces;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using BaseViewModelMvvmHelpers = MvvmHelpers.BaseViewModel;

namespace Ebd.Mobile.ViewModels
{
    public abstract class BaseViewModel : BaseViewModelMvvmHelpers
    {
        protected readonly IDiagnosticService DiagnosticService;
        protected readonly IDialogService DialogService;
        protected readonly ILoggerService Logger;

        protected BaseViewModel(IDiagnosticService diagnosticService, IDialogService dialogService, ILoggerService logger)
        {
            DiagnosticService = diagnosticService;
            DialogService = dialogService;
            Logger = logger;
        }

        protected void CommandOnException(Exception ex)
            => MainThread.BeginInvokeOnMainThread(() => DialogService.DisplayAlert(ex));

        protected int ObterTrimestreAtual() => DateTimeExtension.ObterTrimestreAtual();
        protected DateTime ObterDataAtual() => DateTimeExtension.ObterDataAtual();
        protected bool CanExecute(object args) => IsNotBusy;

        public virtual Task Initialize(object args)
        {
            IsBusy = false;

            return Task.CompletedTask;
        }

        public void HideLoading()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                DialogService.HideLoading();
            });
        }
    }
}
