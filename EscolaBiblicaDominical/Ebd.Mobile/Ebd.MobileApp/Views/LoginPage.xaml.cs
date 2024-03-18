using Ebd.Mobile.ViewModels;

namespace Ebd.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext ??= DependencyInjection.GetService<LoginViewModel>();
        }
    }
}