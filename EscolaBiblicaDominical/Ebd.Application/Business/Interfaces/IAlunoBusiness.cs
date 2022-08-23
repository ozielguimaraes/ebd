using Ebd.Application.Requests.Aluno;
using Ebd.Application.Responses.Aluno;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Application.Business.Interfaces
{
    public interface IAlunoBusiness
    {
        Task<ListaAlunoResponse> Adicionar(AdicionarAlunoRequest request);
        Task<DetalhesAlunoResponse> ObterPorId(int alunoId);
        Task<IEnumerable<ListaAlunoResponse>> ObterPorTurma(int turmaId);
    }
}