using Ebd.Mobile.ViewModels.Chamada;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            await ViewModel.Initialize(null);
        }
    }
}