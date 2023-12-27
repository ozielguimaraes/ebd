using Ebd.Mobile.ViewModels.Aluno;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace Ebd.Mobile.Views.Aluno
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaAlunoPage : ContentPage
    {
        ListaAlunoViewModel ViewModel { get => (ListaAlunoViewModel)BindingContext; }

        public ListaAlunoPage()
        {
            InitializeComponent();
            BindingContext = ViewModel ?? Startup.ServiceProvider.GetService<ListaAlunoViewModel>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.Appearing(null);
        }
    }
}