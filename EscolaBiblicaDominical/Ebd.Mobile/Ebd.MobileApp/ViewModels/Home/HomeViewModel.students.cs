using Ebd.Mobile.ViewModels.Aluno;

namespace Ebd.MobileApp.ViewModels.Home;

internal sealed partial class HomeViewModel : BasePageViewModel
{
    private async Task InitializeStudentsTab(object? parameter = null)
    {
        await Navigate<ListaAlunoViewModel>();
    }
}
