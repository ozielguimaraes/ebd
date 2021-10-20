using Ebd.Application.Requests.Chamada;
using Ebd.Application.Responses.Chamada;
using System.Threading.Tasks;

namespace Ebd.Application.Business.Interfaces
{
    public interface IChamadaBusiness
    {
        Task<EfetuarChamadaResponse> EfetuarChamadaAsync(EfetuarChamadaRequest request);
    }
}
