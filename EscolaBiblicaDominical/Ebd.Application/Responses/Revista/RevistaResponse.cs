using Ebd.Application.Responses.Base;

namespace Ebd.Application.Responses.Revista
{
    public class RevistaResponse : BaseResponse
    {
        public RevistaResponse(int revistaId, string sumario, int ano, int trimestre)
        {
            RevistaId = revistaId;
            Sumario = sumario;
            Ano = ano;
            Trimestre = trimestre;
        }

        public int RevistaId { get; private set; }
        public string Sumario { get; private set; }
        public int Ano { get; private set; }
        public int Trimestre { get; private set; }
    }
}
