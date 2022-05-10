using Ebd.Application.Requests.Revista;
using Ebd.Application.Responses.Revista;
using Ebd.Domain.Core.Entities;
using System;
using System.Collections.Generic;

namespace Ebd.Application.Mappers
{
    public class RevistaMapper
    {
        public static RevistaResponse FromEntityToResponse(Revista entity) => entity is null ? null : new RevistaResponse(
                revistaId: entity.RevistaId,
                turmaId: entity.TurmaId,
                sumario: entity.Sumario,
                ano: entity.Ano,
                trimestre: entity.Trimestre
                );

        public static IEnumerable<RevistaResponse> FromEntityToResponse(IEnumerable<Revista> entities)
        {
            foreach (var item in entities)
                yield return FromEntityToResponse(item);
        }

        internal static Revista FromRequestToEntity(AdicionarRevistaRequest request)
            => new Revista(
                   turmaId: request.TurmaId,
                   sumario: request.Sumario,
                   ano: request.Ano,
                   trimestre: request.Trimestre
                   );
    }
}
