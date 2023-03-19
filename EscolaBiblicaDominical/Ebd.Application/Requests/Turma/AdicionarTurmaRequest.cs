namespace Ebd.Application.Requests.Turma
{
    public class AdicionarTurmaRequest
    {
        public string Nome { get; set; }
        public int IdadeMinima { get; set; }
        public int IdadeMaxima { get; set; }
    }
}
