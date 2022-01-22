using System.Collections.Generic;

namespace Ebd.Domain.Core.Entities
{
    public class Turma
    {
        public int TurmaId { get; set; }
        public string Nome { get; set; }
        public int IdadeMinima { get; set; }
        public int IdadeMaxima { get; set; }

        public ICollection<Aluno> Alunos { get; private set; }
        public ICollection<Professor> Professores { get; private set; }
        public ICollection<Revista> Revistas { get; private set; }
    }
}
