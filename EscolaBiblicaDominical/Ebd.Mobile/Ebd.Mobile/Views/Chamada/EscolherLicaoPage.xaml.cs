using Ebd.Mobile.ViewModels.Chamada;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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