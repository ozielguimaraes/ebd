namespace Ebd.Application.Requests.Revista
{
    public class AdicionarRevistaRequest
    {
        public string Sumario { get; set; }
        public int Ano { get; set; }
        public int Trimestre { get; set; }
        public int TurmaId { get; set; }
    }
}
