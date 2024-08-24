using Ebd.Mobile.Constants;
using Ebd.Mobile.Views;
using Ebd.Mobile.Views.Aluno;
using Ebd.Mobile.Views.Chamada;
using Ebd.MobileApp.Services.Navigation;
using Ebd.MobileApp.Views.Perfil;

namespace Ebd.MobileApp;

public partial class AppShell : Shell
{
    private readonly INavigationService _navigationService;

    public AppShell(INavigationService navigationService)
    {
        _navigationService = navigationService;
        InitializeRouting();

        InitializeComponent();
    }

    private static void InitializeRouting()
    {
        Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
        Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(EfetuarChamadaPage), typeof(EfetuarChamadaPage));

        Routing.RegisterRoute(PageConstant.Aluno.Novo, typeof(NovoAlunoPage));
        Routing.RegisterRoute(PageConstant.Aluno.Lista, typeof(ListaAlunoPage));
        Routing.RegisterRoute(PageConstant.Aluno.ResponsavelAluno.Adicionar, typeof(AdicionarResponsavelPage));

        Routing.RegisterRoute(PageConstant.Perfil.Detalhes, typeof(PerfilPage));
    }

    protected override async void OnHandlerChanged()
    {
        base.OnHandlerChanged();

        if (Handler is not null)
        {
            await _navigationService.InitializeAsync();
        }
    }

    private async void OnMenuItemClicked(object sender, EventArgs e)
    {
        Shell.Current.FlyoutIsPresented = false;
        await Shell.Current.GoToAsync("//LoginPage");
    }
}
