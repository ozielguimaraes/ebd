using Ebd.Mobile.ViewModels.Aluno;

namespace Ebd.Mobile.Views.Aluno
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdicionarResponsavelPage : ContentPage
    {
        AdicionarResponsavelViewModel ViewModel;

        public AdicionarResponsavelPage()
        {
            InitializeComponent();
            BindingContext = ViewModel ??= Startup.ServiceProvider.GetService<AdicionarResponsavelViewModel>();
        }
    }
}