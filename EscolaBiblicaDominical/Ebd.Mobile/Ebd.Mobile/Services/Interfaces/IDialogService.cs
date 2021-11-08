using System;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Interfaces
{
    public interface IDialogService
    {
        Task DisplayAlert(string title, string message);
        Task DisplayAlert(string title, string message, string cancel);
        Task DisplayAlert(Exception ex);
    }
}
