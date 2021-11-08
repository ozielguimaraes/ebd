using Ebd.Mobile.ViewModels.Aluno;
using Xamarin.Essentials;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MainThread.BeginInvokeOnMainThread(() => ViewModel.Initialize(null));
        }
    }
}