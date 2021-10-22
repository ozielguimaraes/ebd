using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Ebd.Mobile.Services.Responses.Aluno;

namespace Ebd.Mobile.ViewModels.Aluno
{
    internal class ListaAlunoViewModel : BaseViewModel
    {
        public ListaAlunoViewModel()
        {
            CarregarListaAlunosCommand = new Command(async () => await ExecuteCarregarListaAlunosCommand());
            Alunos = new ObservableCollection<AlunoResponse>();
        }

        public Command CarregarListaAlunosCommand { get; }

        private ObservableCollection<AlunoResponse> alunos;
        public ObservableCollection<AlunoResponse> Alunos
        {
            get => alunos;
            set => SetProperty(ref alunos, value);
        }

        private async Task ExecuteCarregarListaAlunosCommand()
        {
            IsBusy = true;
            await Task.Delay(900);
            Alunos.Add(new AlunoResponse
            {
                AlunoId = 1,
                Nome = "Johny Messias"
            });
            Alunos.Add(new AlunoResponse
            {
                AlunoId = 2,
                Nome = "Oziel Silva"
            });
            Alunos.Add(new AlunoResponse
            {
                AlunoId = 3,
                Nome = "Sanara Guimarães"
            });

            Alunos.Add(new AlunoResponse
            {
                AlunoId = 4,
                Nome = "Emanuel Silva"
            });

            IsBusy = false;
        }
    }
}
