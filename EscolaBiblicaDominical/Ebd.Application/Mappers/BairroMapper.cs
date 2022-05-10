using Ebd.Application.Responses;
using Ebd.Domain.Core.Entities;
using System.Collections.Generic;

namespace Ebd.Application.Mappers
{
    public class BairroMapper
    {
        public static BairroResponse FromEntityToResponse(Bairro entity) => entity is null ? null : new BairroResponse(entity.BairroId, entity.Nome);

        public static IEnumerable<BairroResponse> FromEntityToResponse(IEnumerable<Bairro> items)
        {
            foreach (var item in items)
                yield return FromEntityToResponse(item);
        }
    }
}
