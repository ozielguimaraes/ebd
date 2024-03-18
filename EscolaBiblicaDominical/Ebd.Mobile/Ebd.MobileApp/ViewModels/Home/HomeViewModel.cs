using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ebd.Mobile.Constants;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Views.Chamada;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace Ebd.MobileApp.ViewModels.Home
{
    internal sealed partial class HomeViewModel : BasePageViewModel
    {
        private readonly ISyncService syncService;
        private readonly ILoggerService loggerService;

        public HomeViewModel(ISyncService syncService, IDiagnosticService diagnosticService, IDialogService dialogService, ILoggerService loggerService) : base(diagnosticService, dialogService, loggerService)
        {
            this.syncService = syncService;
            this.loggerService = loggerService;

            GoToAlunoPageCommand = new AsyncCommand(
                execute: ExecuteGoToAlunoPageCommand,
                onException: CommandOnException);

            GoToEscolherTurmaPageCommand = new AsyncCommand(
                execute: ExecuteGoToEscolherTurmaPageCommand,
                onException: CommandOnException);
        }

        public AsyncCommand GoToAlunoPageCommand { get; private set; }

        public AsyncCommand GoToEscolherTurmaPageCommand { get; }

        [ObservableProperty]
        HomeTab _currentTab;


        [RelayCommand]
        void GoToTab(HomeTab destinationTab)
        {
            if (CurrentTab == destinationTab)
                return;

            CurrentTab = destinationTab;

            switch (CurrentTab)
            {
                case HomeTab.Home:
                    InitializeHomeTab().SafeFireAndForget();
                    break;
                case HomeTab.Classroom:
                    InitializeClassroomTab().SafeFireAndForget();
                    break;
                case HomeTab.Attendance:
                    InitializeAttendanceTab().SafeFireAndForget();
                    break;
                case HomeTab.Profile:
                    InitializeProfileTab().SafeFireAndForget();
                    break;
                default:
                    break;
            }
        }

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
            MainThread.InvokeOnMainThreadAsync(async () =>
            {
                try
                {
                    await syncService.SyncDataAsync();
                }
                catch (Exception exception)
                {
                    loggerService.LogError("Não foi possível syncronizar os dados", exception);
                    //TODO Do something else with this error
                }
            });
        }
    }
}
