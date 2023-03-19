using Ebd.Application.Responses.Base;
using Ebd.Application.Responses.Pessoa;
using Ebd.Application.Responses.Turma;
using System.Collections.Generic;

namespace Ebd.Application.Responses.Aluno
{
    public class DetalhesAlunoResponse : BaseResponse
    {
        public DetalhesAlunoResponse(int alunoId, PessoaResponse pessoa, TurmaResponse turma, ICollection<ResponsavelAlunoResponse> responsaveis)
        {
            AlunoId = alunoId;
            Pessoa = pessoa;
            Turma = turma;
            Responsaveis = responsaveis;
        }

        public int AlunoId { get; private set; }
        public PessoaResponse Pessoa { get; private set; }
        public ICollection<ResponsavelAlunoResponse> Responsaveis { get; private set; }
        public TurmaResponse Turma { get; private set; }
    }
}
