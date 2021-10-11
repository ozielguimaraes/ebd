using Ebd.Application.Requests.Aluno;
using Ebd.Application.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Application.Business.Interfaces
{
    public interface IAlunoBusiness
    {
        Task<AlunoResponse> Adicionar(AdicionarAlunoRequest request);
        Task<IEnumerable<AlunoResponse>> ObterPorTurma(int turmaId);
    }
}