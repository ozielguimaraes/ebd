using Ebd.CrossCutting.Common.Extensions;
using Ebd.Mobile.Services.Interfaces;

namespace Ebd.MobileApp.ViewModels.Home;

internal sealed partial class HomeViewModel : BasePageViewModel
{
    public HomeViewModel(IDiagnosticService diagnosticService, IDialogService dialogService, ILoggerService logger, IAnalyticsService analyticsService, ITurmaService turmaService) : base(diagnosticService, dialogService, logger, analyticsService)
    {
        this.turmaService = turmaService;
    }

    private async Task InitializeHomeTab(object? parameter = null)
    {
        if (IsBusy)
            return;

        IsBusy = true;

        await CertificarQueTurmaFoiSelecionada();

        IsBusy = false;
    }

    public async override Task Appearing(object args)
    {
        if (IsBusy)
            return;

        IsBusy = true;

        await CertificarQueTurmaFoiSelecionada();

        IsBusy = false;
    }

    private async Task CertificarQueTurmaFoiSelecionada()
    {
        if (configuracoesDoUsuarioService.SelecionouUmaTurma.Not())
        {
            try
            {
                await escolherTurmaBottomSheetService.AbrirBottomSheetAsync(false);
            }
            catch (Exception exception)
            {
                Logger.LogError($"{nameof(HomeViewModel)}::{nameof(CertificarQueTurmaFoiSelecionada)}", exception);
            }
        }
    }
}
