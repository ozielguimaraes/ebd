using Ebd.Application.Requests;
using Ebd.Application.Responses;
using System.Threading.Tasks;

namespace Ebd.Application.Business.Interfaces
{
    public interface IAlunoBusiness
    {
        Task<AlunoResponse> Adicionar(AlunoRequest request);
    }
}
