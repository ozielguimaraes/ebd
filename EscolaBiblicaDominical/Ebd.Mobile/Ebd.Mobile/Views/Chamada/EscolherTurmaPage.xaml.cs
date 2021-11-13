using Ebd.Mobile.ViewModels.Chamada;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ebd.Mobile.Views.Chamada
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EscolherTurmaPage : ContentPage
    {
        public EscolherTurmaPage()
        {
            InitializeComponent();
            BindingContext ??= DependencyService.Get<EscolherTurmaViewModel>();
        }
    }
}