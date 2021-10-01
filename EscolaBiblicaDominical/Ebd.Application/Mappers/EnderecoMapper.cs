using Ebd.Application.Requests.Endereco;
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
    }
}
