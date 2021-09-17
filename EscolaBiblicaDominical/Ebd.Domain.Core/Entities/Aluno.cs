namespace Ebd.Domain.Core.Entities
{
    public class Aluno
    {
        public int AlunoId { get; private set; }

        public int PessoaId { get; private set; }
        public Pessoa Pessoa { get; private set; }

        public int? ResponsavelId { get; private set; }
        public Pessoa Responsavel { get; private set; }

        public int TurmaId { get; private set; }
        public Turma Turma { get; private set; }
    }
}
