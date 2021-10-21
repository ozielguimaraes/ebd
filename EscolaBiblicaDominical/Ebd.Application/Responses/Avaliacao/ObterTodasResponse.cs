using Ebd.Application.Responses.Base;

namespace Ebd.Application.Responses.Avaliacao
{
    public class ObterTodasResponse : BaseResponse
    {
        public ObterTodasResponse(int avaliacaoId, int nota, string nome)
        {
            AvaliacaoId = avaliacaoId;
            Nota = nota;
            Nome = nome;
        }

        public int AvaliacaoId { get; private set; }
        public int Nota { get; private set; }
        public string Nome { get; private set; }
    }
}
