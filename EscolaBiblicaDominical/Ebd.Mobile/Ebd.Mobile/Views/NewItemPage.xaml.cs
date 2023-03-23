using Ebd.Mobile.Models;
using Ebd.Mobile.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace Ebd.Mobile.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext ??= Startup.ServiceProvider.GetService<NewItemViewModel>();
        }
    }
}