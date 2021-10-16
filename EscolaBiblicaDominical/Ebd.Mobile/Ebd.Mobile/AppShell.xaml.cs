using Ebd.Mobile.ViewModels;
using Ebd.Mobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Ebd.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = false;
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
