using Ebd.Application.Requests.Contato;
using Ebd.Domain.Core.Entities;
using System.Collections.Generic;
using System.Linq;

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
                    Classificacao = ClassificacaoMapper.FromRequestToEntity(item.Classificacao),
                    Tipo = TipoContatoMapper.FromRequestToEntity(item.Tipo),
                    Valor = item.Valor,
                };
        }
    }
}
