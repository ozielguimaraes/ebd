using CommunityToolkit.Mvvm.Messaging;
using Ebd.Mobile.ViewModels.Aluno;
using Ebd.MobileApp.Messages;

namespace Ebd.Mobile.Views.Aluno
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovoAlunoPage : ContentPage, IRecipient<StringValueChangedMessage>
    {
        NovoAlunoViewModel ViewModel;

        public NovoAlunoPage()
        {
            InitializeComponent();
            WeakReferenceMessenger.Default.Register(this);
            BindingContext = ViewModel ??= Startup.ServiceProvider.GetService<NovoAlunoViewModel>();
            ListaDeBairroBottomSheet.InputTransparent = true;
        }

        public void Receive(StringValueChangedMessage message)
        {
            ListaDeBairroBottomSheet.InputTransparent = false;
            ListaDeBairroBottomSheet.ShowOrHide();
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
        }

        private void SetupBottomSheets()
        {
            //WeakReferenceMessenger.Default.Register<StringValueChangedMessage>(this, (reference, message) =>
            //{
            //    ListaDeBairroBottomSheet.InputTransparent = false;
            //    ListaDeBairroBottomSheet.ShowOrHide();
            //});
        }
    }
}