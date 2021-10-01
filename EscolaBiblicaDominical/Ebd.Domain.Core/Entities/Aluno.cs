namespace Ebd.Domain.Core.Entities
{
    public class Aluno
    {
        public int AlunoId { get; set; }

        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        public int? ResponsavelId { get; set; }
        public Pessoa Responsavel { get; set; }

        public int TurmaId { get; set; }
        public Turma Turma { get; set; }
    }
}
