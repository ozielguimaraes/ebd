using Ebd.Application.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Application.Business.Interfaces
{
    public interface IBairroBusiness
    {
        Task<IEnumerable<BairroResponse>> ObterTodosAsync();
    }
}
