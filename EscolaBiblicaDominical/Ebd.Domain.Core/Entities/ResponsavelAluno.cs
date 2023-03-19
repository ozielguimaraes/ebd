using Ebd.CrossCutting.Enumerators;

namespace Ebd.Domain.Core.Entities
{
    public class ResponsavelAluno
    {
        public int ResponsavelAlunoId { get; set; }
        public TipoResponsavel TipoResponsavel { get; set; }

        public int ResponsavelId { get; set; }
        public Pessoa Responsavel { get; set; }

        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
    }
}
