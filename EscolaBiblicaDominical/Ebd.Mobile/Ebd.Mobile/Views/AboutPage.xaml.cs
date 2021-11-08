using Ebd.Mobile.ViewModels;
using Xamarin.Forms;

namespace Ebd.Mobile.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = DependencyService.Get<AboutViewModel>();
        }
    }
}