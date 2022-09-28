namespace Ebd.Domain.Core.Entities
{
    public class Turma
    {
        public int TurmaId { get; set; }
        public string Nome { get; set; }
        public int IdadeMinima { get; set; }
        public int IdadeMaxima { get; set; }
    }
}
