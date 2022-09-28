using Acr.UserDialogs;
using Ebd.Mobile.Services.Implementations.Diagnostic;
using Ebd.Mobile.Services.Interfaces;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ebd.Mobile.Services.Implementations.Dialog
{
    internal sealed class DialogService : IDialogService
    {
        public static IDialogService Current => DependencyService.Get<IDialogService>();

        public Task DisplayAlert(string title, string message)
            => Application.Current.MainPage.DisplayAlert(title, message, "Ok");

        public Task DisplayAlert(string title, string message, string cancel)
        => Application.Current.MainPage.DisplayAlert(title, message, cancel);

        public Task DisplayAlert(Exception ex)
        {
            return ex switch
            {
                ArgumentException argumentException => Application.Current.MainPage.DisplayAlert(null, argumentException.Message, "Ok"),
                InvalidOperationException invalidOperationException => Application.Current.MainPage.DisplayAlert(null, invalidOperationException.Message, "Ok"),
                TaskCanceledException taskCanceledException => Application.Current.MainPage.DisplayAlert("Operação cancelada", "Operação cancelada pelo usuário", "Ok"),
                _ => Task.Factory.StartNew(() =>
                {
                    DiagnosticService.Current.TrackError(ex);

                    return Application.Current.MainPage.DisplayAlert("Ah não", ex.Message, "Ok");
                })
            };
        }

        public void ShowLoading(string message)
            => UserDialogs.Instance.ShowLoading(
                title: message,
                maskType: MaskType.Black);

        public void HideLoading()
            => UserDialogs.Instance.HideLoading();
    }
}
