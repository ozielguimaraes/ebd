using Ebd.Mobile.Views.Aluno;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ebd.Mobile.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public Command GoToAlunoPageCommand { get; }

        public HomeViewModel()
        {
            GoToAlunoPageCommand = new Command(async () => await ExecuteGoToAlunoPageCommand());
        }

        private async Task ExecuteGoToAlunoPageCommand()
        {
            await Shell.Current.GoToAsync($"{nameof(ListaAlunoPage)}");
        }
    }
}
