using Ebd.Mobile.ViewModels.Aluno;

namespace Ebd.Mobile.Views.Aluno
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaAlunoPage : ContentPage
    {
        ListaAlunoViewModel ViewModel { get => (ListaAlunoViewModel)BindingContext; }

        public ListaAlunoPage()
        {
            InitializeComponent();
            BindingContext = ViewModel ?? DependencyInjection.GetService<ListaAlunoViewModel>();
        }
    }
}