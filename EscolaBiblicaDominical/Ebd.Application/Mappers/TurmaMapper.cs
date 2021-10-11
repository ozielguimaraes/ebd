﻿using Ebd.Application.Responses;
using Ebd.Domain.Core.Entities;
using System.Collections.Generic;

namespace Ebd.Application.Mappers
{
    public class TurmaMapper
    {
        public static TurmaResponse FromEntityToResponse(Turma entity)
        {
            return new TurmaResponse(
                turmaId: entity.TurmaId,
                nome: entity.Nome,
                idadeMaxima: entity.IdadeMaxima,
                idadeMinima: entity.IdadeMinima
                );
        }

        public static IEnumerable<TurmaResponse> FromEntityToResponse(ICollection<Turma> entities)
        {
            foreach (var item in entities)
                yield return FromEntityToResponse(item);
        }
    }
}
