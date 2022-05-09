using Ebd.Application.Responses.Licao;
using Ebd.Domain.Core.Entities;
using System.Collections.Generic;

namespace Ebd.Application.Mappers
{
    public class LicaoMapper
    {
        public static LicaoResponse FromEntityToResponse(Licao entity) => entity is null ? null : new LicaoResponse(entity.LicaoId, entity.Titulo, entity.RevistaId);

        public static IEnumerable<LicaoResponse> FromEntityToResponse(IEnumerable<Licao> entities)
        {
            foreach (var item in entities)
                yield return FromEntityToResponse(item);
        }
    }
}
