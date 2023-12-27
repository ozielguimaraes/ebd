using Ebd.Mobile.ViewModels;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace Ebd.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private readonly HomeViewModel viewModel;

        public HomePage()
        {
            InitializeComponent();
            BindingContext = viewModel = Startup.ServiceProvider.GetService<HomeViewModel>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.OnAppearing();
        }
    }
}