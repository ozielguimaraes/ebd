using Ebd.Application.Requests.Aluno;
using Ebd.Application.Responses.Aluno;
using Ebd.Domain.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Ebd.Application.Mappers
{
    public class AlunoMapper
    {
        public static Aluno FromRequestToEntity(AdicionarAlunoRequest request) =>
            request is null ? null : new Aluno
            {
                Pessoa = new Pessoa
                {
                    Nome = request.Nome,
                    NascidoEm = request.NascidoEm,
                    WhatsappIgualCelular = request.WhatsappIgualCelular,
                    Contatos = ContatoMapper.FromRequestToEntity(request.Contatos)?.ToList(),
                    Enderecos = EnderecoMapper.FromRequestToEntity(request.Enderecos)?.ToList(),
                },
                Responsaveis = PessoaResponsavelMapper.FromRequestToEntity(request.Responsaveis),
                TurmaId = request.TurmaId
            };

        public static ListaAlunoResponse FromEntityToResponse(Aluno entity) =>
            entity is null ? null : new ListaAlunoResponse(entity.AlunoId, entity.Pessoa.Nome);

        public static DetalhesAlunoResponse FromEntityToDetalhesResponse(Aluno entity)
        {
            if (entity is null) return null;

            return new DetalhesAlunoResponse(
                alunoId: entity.AlunoId,
                pessoa: PessoaMapper.FromEntityToResponse(entity.Pessoa),
                turma: TurmaMapper.FromEntityToResponse(entity.Turma),
                responsaveis: PessoaResponsavelMapper.FromEntityToResponse(entity.Responsaveis)
                );
        }

        public static IEnumerable<ListaAlunoResponse> FromEntityToResponse(ICollection<Aluno> entities)
        {
            foreach (var item in entities)
                yield return FromEntityToResponse(item);
        }
    }
}
