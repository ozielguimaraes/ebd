using Ebd.Mobile.ViewModels.Chamada;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace Ebd.Mobile.Views.Chamada
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EfetuarChamadaPage : ContentPage
    {
        EfetuarChamadaViewModel ViewModel { get => (EfetuarChamadaViewModel)BindingContext; }

        public EfetuarChamadaPage()
        {
            InitializeComponent();
            BindingContext ??= Startup.ServiceProvider.GetService<EfetuarChamadaViewModel>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.Appearing(null);
        }
    }
}