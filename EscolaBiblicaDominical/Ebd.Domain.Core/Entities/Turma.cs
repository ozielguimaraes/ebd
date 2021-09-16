using System.Collections.Generic;

namespace Ebd.Domain.Core.Entities
{
    public class Turma
    {
        public int TurmaId { get; private set; }
        public string Nome { get; private set; }
        public int IdadeMinima { get; private set; }
        public int IdadeMaxima { get; private set; }

        public ICollection<Aluno> Alunos { get; private set; }
        public ICollection<Professor> Professores { get; private set; }
    }
}
