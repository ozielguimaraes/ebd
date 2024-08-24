using Ebd.MobileApp.ViewModels;

namespace Ebd.MobileApp.Services.Navigation;

public interface INavigationService
{
    Task Navigate<TViewModel>(object? parameter = null, bool animated = true)
        where TViewModel : BasePageViewModel;

    void Initialize(object? parameters = null);
    Task InitializeAsync();
}