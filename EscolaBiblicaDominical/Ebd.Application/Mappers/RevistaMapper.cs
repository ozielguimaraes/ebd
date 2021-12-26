using Ebd.Application.Responses.Revista;
using Ebd.Domain.Core.Entities;
using System.Collections.Generic;

namespace Ebd.Application.Mappers
{
    public class RevistaMapper
    {
        public static RevistaResponse FromEntityToResponse(Revista entity)
        {
            return new RevistaResponse(
                revistaId: entity.RevistaId, 
                sumario: entity.Sumario,
                ano: entity.Ano,
                trimestre: entity.Trimestre
                );
        }

        public static IEnumerable<RevistaResponse> FromEntityToResponse(IEnumerable<Revista> entities)
        {
            foreach (var item in entities)
                yield return FromEntityToResponse(item);
        }
    }
}
