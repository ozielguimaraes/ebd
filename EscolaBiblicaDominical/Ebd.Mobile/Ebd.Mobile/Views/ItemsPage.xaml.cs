using Ebd.Mobile.ViewModels;
using Xamarin.Forms;

namespace Ebd.Mobile.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel ViewModel { get => (ItemsViewModel)BindingContext; }

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext ??= DependencyService.Get<ItemsViewModel>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.OnAppearing();
        }
    }
}