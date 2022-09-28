namespace Ebd.Domain.Core.Entities
{
    public class AvaliacaoAluno
    {
        public AvaliacaoAluno(int avaliacaoId, int alunoId, int licaoId)
        {
            AvaliacaoId = avaliacaoId;
            AlunoId = alunoId;
            LicaoId = licaoId;
        }

        public int AvaliacaoAlunoId { get; set; }
        public int AvaliacaoId { get; set; }
        public Avaliacao Avaliacao { get; set; }

        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public int LicaoId { get; private set; }
        public Licao Licao { get; private set; }
    }
}
