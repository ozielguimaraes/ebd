using Ebd.Mobile.Services.Responses.Avaliacao;
using MvvmHelpers;

namespace Ebd.Mobile.Models
{
    public class RealizarAvaliacao : ObservableObject
    {
        public RealizarAvaliacao(AvaliacaoResponse avaliacaoResponse)
        {
            AvaliacaoId = avaliacaoResponse.AvaliacaoId;
            Nome = avaliacaoResponse.Nome;
        }

        public RealizarAvaliacao(int id, string nome)
        {
            AvaliacaoId = id;
            Nome = nome;
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
