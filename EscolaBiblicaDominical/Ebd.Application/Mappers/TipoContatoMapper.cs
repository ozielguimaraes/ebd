using Ebd.Application.Requests.Contato;
using Ebd.Domain.Core.Entities.Enumerators;

namespace Ebd.Application.Mappers
{
    public class TipoContatoMapper
    {
        public static TipoContato FromRequestToEntity(TipoContatoRequest request)
            => (TipoContato)request;
    }
}
