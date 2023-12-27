namespace Ebd.Mobile.Services.Responses.Turma
{
    public class TurmaResponse
    {
        public int TurmaId { get; set; }
        public string Nome { get; set; }
        public int IdadeMinima { get; set; }
        public int IdadeMaxima { get; set; }
        public string FaixaIdadeNome => $"{IdadeMinima} à {IdadeMaxima} - {Nome}";

        public override bool Equals(object obj)
        {
            return obj is TurmaResponse response &&
                   TurmaId == response.TurmaId &&
                   Nome == response.Nome &&
                   IdadeMinima == response.IdadeMinima &&
                   IdadeMaxima == response.IdadeMaxima;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
