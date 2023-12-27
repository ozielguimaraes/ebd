using Ebd.Mobile.ViewModels.Aluno;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

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