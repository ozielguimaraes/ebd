using Ebd.Mobile.ViewModels.Aluno;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ebd.Mobile.Views.Aluno
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovoAlunoPage : ContentPage
    {
        NovoAlunoViewModel ViewModel;

        public NovoAlunoPage()
        {
            InitializeComponent();
            BindingContext = ViewModel ??= Startup.ServiceProvider.GetService<NovoAlunoViewModel>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.Appearing(null);
        }
    }
}