using Ebd.Mobile.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace Ebd.Mobile.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel ViewModel { get => (ItemsViewModel)BindingContext; }

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext ??= DependencyInjection.GetService<ItemsViewModel>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.OnAppearing();
        }
    }
}