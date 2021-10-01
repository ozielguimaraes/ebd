using Ebd.Application.Requests.Contato;
using Ebd.Application.Requests.Endereco;
using Ebd.Domain.Core.Entities.Enumerators;

namespace Ebd.Application.Mappers
{
    public class ClassificacaoMapper
    {
        public static ClassificacaoEndereco FromRequestToEntity(ClassificacaoEnderecoRequest request)
            => (ClassificacaoEndereco)request;

        public static ClassificacaoContato FromRequestToEntity(ClassificacaoContatoRequest request)
            => (ClassificacaoContato)request;

        public static ClassificacaoEnderecoRequest FromEntityToRequest(ClassificacaoEndereco entity)
            => (ClassificacaoEnderecoRequest)entity;
    }
}
