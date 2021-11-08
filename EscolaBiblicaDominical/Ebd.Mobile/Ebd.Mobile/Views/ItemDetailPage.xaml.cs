using Ebd.Mobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Ebd.Mobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext ??= DependencyService.Get<ItemDetailViewModel>();
        }
    }
}