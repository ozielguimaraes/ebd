using Ebd.Mobile.Constants;
using Ebd.Mobile.Views.Chamada;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ebd.Mobile.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        //public HomeViewModel(IDiagnosticService diagnosticService, IDialogService dialogService, ILoggerService logger) //: base(diagnosticService, dialogService, logger)
        //{
        //    GoToAlunoPageCommand = new Command(async () => await ExecuteGoToAlunoPageCommand());
        //}

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
    }
}
