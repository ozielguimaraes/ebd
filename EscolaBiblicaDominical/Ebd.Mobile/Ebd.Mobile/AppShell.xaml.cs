﻿using Xamarin.Forms;
using Ebd.Mobile.Views;
using Ebd.Mobile.Views.Aluno;
using Ebd.Mobile.Views.Chamada;
using System;

namespace Ebd.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(ListaAlunoPage), typeof(ListaAlunoPage));
            Routing.RegisterRoute(nameof(EfetuarChamadaPage), typeof(EfetuarChamadaPage));
            Routing.RegisterRoute(nameof(EscolherTurmaPage), typeof(EscolherTurmaPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = false;
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
