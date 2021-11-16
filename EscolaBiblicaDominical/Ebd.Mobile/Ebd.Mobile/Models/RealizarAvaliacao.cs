using Ebd.Mobile.Services.Responses.Avaliacao;

namespace Ebd.Mobile.Models
{
    public class RealizarAvaliacao
    {
        public RealizarAvaliacao(AvaliacaoResponse avaliacaoResponse)
        {
            AvaliacaoId = avaliacaoResponse.AvaliacaoId;
            Nome = avaliacaoResponse.Nome;
        }

        public int AvaliacaoId { get; private set; }
        public string Nome { get; private set; }
        public bool FoiRealizada { get; set; }
    }
}
