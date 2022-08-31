using Ebd.Application.Requests.Pessoa;
using Ebd.Application.Responses.Pessoa;
using Ebd.Domain.Core.Entities;
using System.Linq;

namespace Ebd.Application.Mappers
{
    public class PessoaMapper
    {
        public static PessoaResponse FromEntityToResponse(Pessoa entity) =>
            entity is null ? null : new PessoaResponse(
                pessoaId: entity.PessoaId,
                nome: entity.Nome,
                whatsappIgualCelular: entity.WhatsappIgualCelular,
                nascidoEm: entity.NascidoEm,
                enderecos: EnderecoMapper.FromEntityToResponse(entity.Enderecos),
                contatos: ContatoMapper.FromEntityToResponse(entity.Contatos)
                );

        public static Pessoa FromRequestToEntity(PessoaRequest request) =>
            request is null ? null : new Pessoa
            {
                Nome = request.Nome,
                WhatsappIgualCelular = request.WhatsappIgualCelular,
                NascidoEm = request.NascidoEm,
                Enderecos = EnderecoMapper.FromRequestToEntity(request.Enderecos)?.ToList(),
                Contatos = ContatoMapper.FromRequestToEntity(request.Contatos)?.ToList()
            };

    }
}
