using Ebd.MobileApp.ViewModels.Perfil;

namespace Ebd.MobileApp.ViewModels.Home;

internal sealed partial class HomeViewModel : BasePageViewModel
{
    private async Task InitializeProfileTab(object? parameter = null)
    {
        await Navigate<PerfilPageViewModel>();
    }
}
