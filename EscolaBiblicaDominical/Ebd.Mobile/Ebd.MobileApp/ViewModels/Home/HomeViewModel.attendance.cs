using Ebd.Mobile.Views.Chamada;

namespace Ebd.MobileApp.ViewModels.Home;

internal sealed partial class HomeViewModel : BasePageViewModel
{
    private async Task InitializeAttendanceTab(object? parameter = null)
    {
        await Shell.Current.GoToAsync($"{nameof(EscolherTurmaPage)}");
    }
}
