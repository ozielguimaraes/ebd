namespace Ebd.Domain.Core.Entities
{
    public class Professor
    {
        public int ProfessorId { get; private set; }

        public int PessoaId { get; private set; }
        public Pessoa Pessoa { get; private set; }

        public int TurmaId { get; private set; }
        public Turma Turma { get; private set; }
    }
}