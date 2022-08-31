using Ebd.Application.Requests.Endereco;
using Ebd.Application.Responses;
using Ebd.Application.Responses.Endereco;
using Ebd.Domain.Core.Entities;
using System.Collections.Generic;

namespace Ebd.Application.Mappers
{
    public class EnderecoMapper
    {
        public static IEnumerable<Endereco> FromRequestToEntity(IEnumerable<EnderecoRequest> items)
        {
            foreach (var item in items)
                yield return new Endereco
                {
                    BairroId = item.BairroId,
                    Cep = item.Cep,
                    EnderecoId = item.EnderecoId,
                    Numero = item.Numero,
                    Logradouro = item.Logradouro,
                    Classificacao = ClassificacaoMapper.FromRequestToEntity(item.Classificacao)
                };
        }

        internal static DetalhesEnderecoResponse FromEntityToResponse(Endereco entity)
        {
            if (entity is null) return null;

            return new DetalhesEnderecoResponse(
                enderecoId: entity.EnderecoId,
                classificacao: (ClassificacaoEnderecoResponse)entity.Classificacao,
               logradouro: entity.Logradouro,
               numero: entity.Numero,
               cep: entity.Cep,
               bairro: BairroMapper.FromEntityToResponse(entity.Bairro)
                );
        }

        internal static IEnumerable<DetalhesEnderecoResponse> FromEntityToResponse(ICollection<Endereco> entities)
        {
            foreach (var item in entities)
                yield return FromEntityToResponse(item);
        }
    }
}
