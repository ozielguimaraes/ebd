namespace Ebd.Domain.Core.Entities
{
    public class AvaliacaoAluno
    {
        public AvaliacaoAluno(int avaliacaoId, int alunoId)
        {
            AvaliacaoId = avaliacaoId;
            AlunoId = alunoId;
        }

        public int AvaliacaoAlunoId { get; set; }
        public int AvaliacaoId { get; set; }
        public Avaliacao Avaliacao { get; set; }

        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
    }
}
