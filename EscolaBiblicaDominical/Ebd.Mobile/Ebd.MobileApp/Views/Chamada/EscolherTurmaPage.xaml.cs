using Ebd.Mobile.ViewModels.Chamada;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace Ebd.Mobile.Views.Chamada
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EscolherTurmaPage : ContentPage
    {
        EscolherTurmaViewModel ViewModel { get => (EscolherTurmaViewModel)BindingContext; }

        public EscolherTurmaPage()
        {
            InitializeComponent();
            BindingContext = Startup.ServiceProvider.GetService<EscolherTurmaViewModel>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.Appearing(null);
        }
    }
}