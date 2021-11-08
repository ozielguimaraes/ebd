using Ebd.Mobile.ViewModels.Chamada;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ebd.Mobile.Views.Chamada
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EfetuarChamadaPage : ContentPage
    {
        public EfetuarChamadaPage()
        {
            InitializeComponent();
            BindingContext ??= DependencyService.Get<EfetuarChamadaViewModel>();
        }
    }
}