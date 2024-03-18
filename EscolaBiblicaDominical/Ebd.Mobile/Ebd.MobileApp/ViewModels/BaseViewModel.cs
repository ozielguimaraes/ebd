using CommunityToolkit.Mvvm.ComponentModel;
using Ebd.CrossCutting.Common.Extensions;
using Ebd.Mobile.Services.Interfaces;
using Ebd.MobileApp.Services.Navigation;
using Ebd.MobileApp.ViewModels;

namespace Ebd.Mobile.ViewModels
{
    internal abstract partial class BaseViewModel : ObservableObject
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

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool _IsBusy = false;

        public bool IsNotBusy => !IsBusy;

        protected void CommandOnException(Exception ex)
            => MainThread.BeginInvokeOnMainThread(() => DialogService.DisplayAlert(ex));

        protected int ObterTrimestreAtual() => DateTimeExtension.ObterTrimestreAtual();
        protected DateTime ObterDataAtual() => DateTimeExtension.ObterDataAtual();
        protected bool CanExecute(object args) => IsNotBusy;

        public virtual Task Appearing(object args)
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

        protected Task Navigate<TPageViewModel>(object? parameter = null)
            where TPageViewModel : BasePageViewModel
            => NavigationService.Current.Navigate<TPageViewModel>(parameter);
    }
}
