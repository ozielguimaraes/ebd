using Ebd.Application.Requests.Contato;
using Ebd.Application.Responses.Contato;
using Ebd.Domain.Core.Entities;
using System.Collections.Generic;

namespace Ebd.Application.Mappers
{
    public class ContatoMapper
    {
        public static IEnumerable<Contato> FromRequestToEntity(IEnumerable<ContatoRequest> items)
        {
            if (items is null) yield break;

            foreach (var item in items)
                yield return new Contato
                {
                    ContatoId = item.ContatoId,
                    Classificacao = item.Classificacao,
                    Tipo = item.Tipo,
                    Valor = item.Valor,
                };
        }

        internal static IEnumerable<DetalhesContatoResponse> FromEntityToResponse(ICollection<Contato> items)
        {
            foreach (var item in items)
                yield return new DetalhesContatoResponse(
                    contatoId: item.ContatoId,
                    valor: item.Valor,
                    tipo: item.Tipo,
                    classificacao: item.Classificacao
                    );
        }
    }
}
