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
            ViewModel.OnTurmaSelecionadaChanged += ViewModel_OnTurmaSelecionadaChanged;
        }

        private async void ViewModel_OnTurmaSelecionadaChanged(object? sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(
                async () => await ViewModel.CarregarListaAlunosCommand.ExecuteAsync(true)
            );
        }

    }
}