﻿using Ebd.Mobile.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace Ebd.Mobile.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel ViewModel { get => (ItemsViewModel)BindingContext; }

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext ??= Startup.ServiceProvider.GetService<ItemsViewModel>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.OnAppearing();
        }
    }
}