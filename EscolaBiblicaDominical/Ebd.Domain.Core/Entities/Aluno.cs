using System.Collections.Generic;

namespace Ebd.Domain.Core.Entities
{
    public class Aluno
    {
        public int AlunoId { get; set; }

        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }

        public IEnumerable<ResponsavelAluno> Responsaveis { get; set; }

        public int TurmaId { get; set; }
        public Turma Turma { get; set; }
        public IEnumerable<AvaliacaoAluno> AvaliacoesAluno { get; set; }
    }
}
