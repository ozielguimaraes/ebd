using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.ViewModels.Aluno;
using Ebd.MobileApp.Services.Interfaces.BottomSheets;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace Ebd.MobileApp.ViewModels.Home
{
    internal sealed partial class HomeViewModel : BasePageViewModel
    {
        private readonly ISyncService syncService;
        private readonly IEscolherTurmaBottomSheetService escolherTurmaBottomSheetService;
        private readonly ITurmaService turmaService;
        private readonly IDialogService dialogService;
        private readonly IConfiguracoesDoUsuarioService configuracoesDoUsuarioService;

        public HomeViewModel(ISyncService syncService, IDiagnosticService diagnosticService, IDialogService dialogService, ILoggerService loggerService, IEscolherTurmaBottomSheetService escolherTurmaBottomSheetService, IConfiguracoesDoUsuarioService configuracoesDoUsuarioService, IAnalyticsService analyticsService, ITurmaService turmaService) : base(diagnosticService, dialogService, loggerService, analyticsService)
        {
            this.syncService = syncService;
            this.escolherTurmaBottomSheetService = escolherTurmaBottomSheetService;
            this.configuracoesDoUsuarioService = configuracoesDoUsuarioService;
            this.turmaService = turmaService;
            this.dialogService = dialogService;

            SetupScreenName("Inicio");
            Title = "Inicio";
        }

        public AsyncCommand GoToAlunoPageCommand { get; private set; }

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
                case HomeTab.Students:
                    InitializeStudentsTab().SafeFireAndForget();
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
            if (IsBusy) return;
            IsBusy = true;
            await Navigate<ListaAlunoViewModel>();
            //await Shell.Current.GoToAsync(PageConstant.Aluno.Lista);
            IsBusy = false;
        }

        public async override Task OnAppearingAsync(object? parameter = null)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            await base.OnAppearingAsync(parameter);

            IsBusy = false;
        }
    }
}
