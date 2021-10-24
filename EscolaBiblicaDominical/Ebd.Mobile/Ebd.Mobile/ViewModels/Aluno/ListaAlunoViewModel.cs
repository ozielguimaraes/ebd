using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Ebd.Mobile.Services.Responses.Aluno;
using Ebd.Mobile.Services.Interfaces;
using Xamarin.Forms.Internals;

namespace Ebd.Mobile.ViewModels.Aluno
{
    internal class ListaAlunoViewModel : BaseViewModel
    {
        private readonly IAlunoService _alunoService;

        public ListaAlunoViewModel(IAlunoService alunoService = null)
        {
            CarregarListaAlunosCommand = new Command(async () => await ExecuteCarregarListaAlunosCommand());
            Alunos = new ObservableCollection<AlunoResponse>();
            _alunoService = alunoService;
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
            var alunos = await _alunoService.ObterTodosAsync();

            alunos.ForEach(x => Alunos.Add(x));

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
