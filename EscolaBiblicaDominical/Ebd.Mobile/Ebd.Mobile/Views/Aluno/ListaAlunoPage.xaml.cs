using Ebd.Mobile.ViewModels.Aluno;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ebd.Mobile.Views.Aluno
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaAlunoPage : ContentPage
    {
        public ListaAlunoPage()
        {
            InitializeComponent();
            BindingContext = new ListaAlunoViewModel();
        }

        protected override void OnAppearing()
        {
            (BindingContext as ListaAlunoViewModel).CarregarListaAlunosCommand.Execute(null);
            base.OnAppearing();
        }
    }
}