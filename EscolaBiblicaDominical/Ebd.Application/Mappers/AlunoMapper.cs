using Ebd.Application.Requests.Aluno;
using Ebd.Application.Responses;
using Ebd.Domain.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Ebd.Application.Mappers
{
    public class AlunoMapper
    {
        public static Aluno FromRequestToEntity(AdicionarAlunoRequest request) => request is null ? null : new Aluno
        {
            Pessoa = new Pessoa
            {
                Nome = request.Nome,
                NascidoEm = request.NascidoEm,
                WhatsappIgualCelular = request.WhatsappIgualCelular,
                Contatos = ContatoMapper.FromRequestToEntity(request.Contatos).ToList(),
                Enderecos = EnderecoMapper.FromRequestToEntity(request.Enderecos).ToList(),
            },
            TurmaId = request.TurmaId
        };

        public static AlunoResponse FromEntityToResponse(Aluno entity) => entity is null ? null : new AlunoResponse(entity.AlunoId, entity.Pessoa.Nome);

        public static IEnumerable<AlunoResponse> FromEntityToResponse(ICollection<Aluno> entities)
        {
            foreach (var item in entities)
                yield return FromEntityToResponse(item);
        }
    }
}
