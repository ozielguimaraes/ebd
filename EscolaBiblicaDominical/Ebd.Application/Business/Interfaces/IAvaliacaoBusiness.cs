using Ebd.Application.Responses.Avaliacao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Application.Business.Interfaces
{
    public interface IAvaliacaoBusiness
    {
        Task<IEnumerable<ObterTodasResponse>> ObterTodasAsync();
    }
}
