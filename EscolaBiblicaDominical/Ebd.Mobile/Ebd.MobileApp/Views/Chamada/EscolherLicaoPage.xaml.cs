using Ebd.Mobile.ViewModels.Chamada;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace Ebd.Mobile.Views.Chamada
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EscolherLicaoPage : ContentPage
    {
        EfetuarChamadaViewModel ViewModel { get => (EfetuarChamadaViewModel)BindingContext; }

        public EscolherLicaoPage()
        {
            InitializeComponent();
            BindingContext = ViewModel ?? Startup.ServiceProvider.GetService<EfetuarChamadaViewModel>();
        }
    }
}