using Ebd.Mobile.Services.Responses.Avaliacao;

namespace Ebd.Mobile.ViewModels.Chamada
{
    public class RealizarAvaliacaoVm : BaseViewModel
    {
        public RealizarAvaliacaoVm(AvaliacaoResponse avaliacaoResponse)
        {
            AvaliacaoId = avaliacaoResponse.AvaliacaoId;
            Nome = avaliacaoResponse.Nome;
        }

        public int AvaliacaoId { get; private set; }
        public string Nome { get; private set; }

        private bool foiRealizada;
        public bool FoiRealizada
        {
            get => foiRealizada;
            set => SetProperty(ref foiRealizada, value);
        }
    }
}
