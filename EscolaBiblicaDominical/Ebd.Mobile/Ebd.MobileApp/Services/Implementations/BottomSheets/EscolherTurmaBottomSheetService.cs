using Ebd.Mobile;
using Ebd.Mobile.Services.Implementations.Dialog;
using Ebd.Mobile.Services.Interfaces;
using Ebd.MobileApp.Services.Interfaces.BottomSheets;
using Ebd.MobileApp.Views.Turma;

namespace Ebd.MobileApp.Services.Implementations.BottomSheets;

public class EscolherTurmaBottomSheetService : IEscolherTurmaBottomSheetService
{
    private EscolherTurmaBottomSheet? EscolherTurmaBottomSheet;

    public async Task AbrirBottomSheetAsync(bool usuarioPodeFechar)
    {
        EscolherTurmaBottomSheet ??= new EscolherTurmaBottomSheet
        {
            HasHandle = true,
            IsCancelable = usuarioPodeFechar
        };

        await EscolherTurmaBottomSheet.LoadDataAsync();
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {

            var dialogService = DependencyInjection.GetService<IDialogService>();
            dialogService.HideLoading();
            await Task.Delay(300);
            await EscolherTurmaBottomSheet.ShowAsync();
        });
    }

    public async Task FecharBottomSheetAsync()
    {
        if (EscolherTurmaBottomSheet is null)
            return;

        await EscolherTurmaBottomSheet.DismissAsync();
    }

    public void Dispose()
    {
        EscolherTurmaBottomSheet = null;
    }
}
