using Ebd.Application.Responses.Base;
using Ebd.Application.Responses.Pessoa;
using Ebd.Application.Responses.Turma;

namespace Ebd.Application.Responses.Aluno
{
    public class DetalhesAlunoResponse : BaseResponse
    {
        public DetalhesAlunoResponse(int alunoId, PessoaResponse pessoa, PessoaResponse responsavel, TurmaResponse turma)
        {
            AlunoId = alunoId;
            Pessoa = pessoa;
            Responsavel = responsavel;
            Turma = turma;
        }

        public int AlunoId { get; private set; }
        public PessoaResponse Pessoa { get; private set; }
        public PessoaResponse? Responsavel { get; private set; }
        public TurmaResponse Turma { get; private set; }
    }
}
