using Ebd.Application.Requests.Pessoa;
using Ebd.Application.Responses.Aluno;
using Ebd.Domain.Core.Entities;
using System.Collections.Generic;

namespace Ebd.Application.Mappers
{
    public class PessoaResponsavelMapper
    {
        public static List<ResponsavelAluno> FromRequestToEntity(IEnumerable<ResponsavelAlunoRequest> items)
        {
            var result = new List<ResponsavelAluno>();

            foreach (var item in items)
            {
                result.Add(FromRequestToEntity(item));
            }

            return result;
        }

        public static ResponsavelAluno FromRequestToEntity(ResponsavelAlunoRequest request) =>
            request is null ? null : new ResponsavelAluno
            {
                AlunoId = request.AlunoId,
                ResponsavelId = request.PessoaId,
                Responsavel = PessoaMapper.FromRequestToEntity(request.Pessoa),
                ResponsavelAlunoId = request.PessoaResponsavelId,
                TipoResponsavel = request.TipoResponsavel
            };

        public static ResponsavelAlunoResponse FromEntityToResponse(ResponsavelAluno entity) =>
            entity is null ? null : new ResponsavelAlunoResponse(
                pessoaResponsavelId: entity.ResponsavelAlunoId,
                alunoId: entity.AlunoId,
                responsavelId: entity.ResponsavelId,
                responsavel: PessoaMapper.FromEntityToResponse(entity.Responsavel)
                );

        internal static List<ResponsavelAlunoResponse> FromEntityToResponse(IEnumerable<ResponsavelAluno> responsaveis)
        {
            var result = new List<ResponsavelAlunoResponse>();

            foreach (var item in responsaveis)
            {
                result.Add(FromEntityToResponse(item));
            }

            return result;
        }
    }
}
