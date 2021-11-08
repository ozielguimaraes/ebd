using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Views;
using Ebd.Mobile.Views.Aluno;
using MvvmHelpers.Commands;
using System.Threading.Tasks;
using Xamarin.Essentials;
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

        private async Task ExecuteGoToAlunoPageCommand()
        {
            await Shell.Current.GoToAsync($"{nameof(ListaAlunoPage)}");
        }
    }
}
