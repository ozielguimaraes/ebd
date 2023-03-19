namespace Ebd.Domain.Core.Entities
{
    public class Turma
    {
        public Turma(string nome, int idadeMinima, int idadeMaxima)
        {
            Nome = nome;
            IdadeMinima = idadeMinima;
            IdadeMaxima = idadeMaxima;
        }
        public Turma(int turmaId, string nome, int idadeMinima, int idadeMaxima)
        {
            TurmaId = turmaId;
            Nome = nome;
            IdadeMinima = idadeMinima;
            IdadeMaxima = idadeMaxima;
        }

        public int TurmaId { get; private set; }
        public string Nome { get; private set; }
        public int IdadeMinima { get; private set; }
        public int IdadeMaxima { get; private set; }
    }
}
