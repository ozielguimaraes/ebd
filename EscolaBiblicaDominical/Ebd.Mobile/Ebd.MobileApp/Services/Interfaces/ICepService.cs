using Ebd.Mobile.Services.Responses;
using Ebd.Mobile.Services.Responses.Cep;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Interfaces
{
    public interface ICepService
    {
        Task<BaseResponse<CepResponse>> ObterAsync(string cep);
    }
}
