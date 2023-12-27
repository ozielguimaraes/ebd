using Ebd.Mobile.Constants;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Views.Chamada;
using MvvmHelpers.Commands;

namespace Ebd.Mobile.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly ISyncService syncService;

        public HomeViewModel(ISyncService syncService, IDiagnosticService diagnosticService, IDialogService dialogService, ILoggerService loggerService) : base(diagnosticService, dialogService, loggerService)
        {
            this.syncService = syncService;
        }

        private readonly AsyncCommand _goToAlunoPageCommand;
        public AsyncCommand GoToAlunoPageCommand
            => _goToAlunoPageCommand
            ?? new AsyncCommand(
                execute: ExecuteGoToAlunoPageCommand,
                onException: CommandOnException);

        private readonly AsyncCommand _goToEscolherTurmaPageCommand;
        public AsyncCommand GoToEscolherTurmaPageCommand
            => _goToEscolherTurmaPageCommand
            ?? new AsyncCommand(
                execute: ExecuteGoToEscolherTurmaPageCommand,
                onException: CommandOnException);

        private async Task ExecuteGoToAlunoPageCommand()
        {
            await Shell.Current.GoToAsync(PageConstant.Aluno.Lista);
        }

        private async Task ExecuteGoToEscolherTurmaPageCommand()
        {
            await Shell.Current.GoToAsync($"{nameof(EscolherTurmaPage)}");
        }

        internal void OnAppearing()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await syncService.SyncDataAsync();
            });
        }
    }
}
