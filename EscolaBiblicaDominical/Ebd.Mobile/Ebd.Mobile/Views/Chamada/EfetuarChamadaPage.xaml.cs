using Ebd.Mobile.ViewModels.Chamada;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ebd.Mobile.Views.Chamada
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EfetuarChamadaPage : ContentPage
    {
        EfetuarChamadaViewModel ViewModel { get => (EfetuarChamadaViewModel)BindingContext; }

        public EfetuarChamadaPage()
        {
            InitializeComponent();
            BindingContext ??= DependencyService.Get<EfetuarChamadaViewModel>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.Initialize(null);
        }
    }
}