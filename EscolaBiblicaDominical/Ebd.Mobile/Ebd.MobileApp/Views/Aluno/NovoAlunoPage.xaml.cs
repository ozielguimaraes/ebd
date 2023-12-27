using Ebd.Mobile.ViewModels.Aluno;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

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
            ListaDeBairroBottomSheet.InputTransparent = true;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            SetupBottomSheets();
            await ViewModel.Appearing(null);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<NovoAlunoViewModel>(this, NovoAlunoViewModel.BottomSheetSelecionarBairro);
        }

        private void SetupBottomSheets()
        {
            MessagingCenter.Subscribe<NovoAlunoViewModel>(this, NovoAlunoViewModel.BottomSheetSelecionarBairro, (sender) =>
            {
                ListaDeBairroBottomSheet.InputTransparent = false;
                ListaDeBairroBottomSheet.ShowOrHide();
            });
        }
    }
}