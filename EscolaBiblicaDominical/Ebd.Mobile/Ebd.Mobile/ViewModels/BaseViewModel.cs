using Ebd.Mobile.Extensions;
using Ebd.Mobile.Models;
using Ebd.Mobile.Services;
using Ebd.Mobile.Services.Implementations.Dialog;
using Ebd.Mobile.Services.Implementations.Diagnostic;
using Ebd.Mobile.Services.Implementations.Logger;
using Ebd.Mobile.Services.Interfaces;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using BaseViewModelMvvmHelpers = MvvmHelpers.BaseViewModel;

namespace Ebd.Mobile.ViewModels
{
    public abstract class BaseViewModel : BaseViewModelMvvmHelpers
    {
        //protected readonly IDiagnosticService DiagnosticService;
        //protected readonly IDialogService DialogService;
        //protected readonly ILoggerService Logger;
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        private static readonly Lazy<IDiagnosticService> DiagnosticServiceLazy = new(() => new DiagnosticService());
        private static readonly Lazy<IDialogService> DialogServiceLazy = new(() => new DialogService());
        private static readonly Lazy<ILoggerService> LoggerLazy = new(() => new LoggerService());

        public readonly IDiagnosticService DiagnosticService = DiagnosticServiceLazy.Value;
        public readonly IDialogService DialogService = DialogServiceLazy.Value;
        public readonly ILoggerService Logger = LoggerLazy.Value;

        //protected BaseViewModel(IDiagnosticService diagnosticService, IDialogService dialogService, ILoggerService logger)
        //{
        //    DiagnosticService = diagnosticService;
        //    DialogService = dialogService;
        //    Logger = logger;
        //}

        protected void CommandOnException(Exception ex)
            => MainThread.BeginInvokeOnMainThread(() => DialogService.DisplayAlert(ex));

        protected int ObterTrimestreAtual() => DateTimeExtension.ObterTrimestreAtual();
        protected DateTime ObterDataAtual() => DateTimeExtension.ObterDataAtual();

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
