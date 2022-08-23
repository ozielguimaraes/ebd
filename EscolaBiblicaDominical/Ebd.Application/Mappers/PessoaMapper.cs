using Ebd.Application.Responses.Pessoa;
using Ebd.Domain.Core.Entities;

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

    }
}
