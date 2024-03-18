using Ebd.MobileApp.ViewModels.Home;

namespace Ebd.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private readonly HomeViewModel viewModel;

        public HomePage()
        {
            InitializeComponent();
            BindingContext = viewModel = DependencyInjection.GetService<HomeViewModel>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}