using Ebd.Mobile.ViewModels.Aluno;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ebd.Mobile.Views.Aluno
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaAlunoPage : ContentPage
    {
        ListaAlunoViewModel ViewModel { get => (ListaAlunoViewModel)BindingContext; }

        public ListaAlunoPage()
        {
            InitializeComponent();
            BindingContext = ViewModel ?? DependencyService.Get<ListaAlunoViewModel>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.Initialize(null);
        }
    }
}