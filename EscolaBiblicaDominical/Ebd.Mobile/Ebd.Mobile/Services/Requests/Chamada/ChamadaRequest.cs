using System.Collections.Generic;

namespace Ebd.Mobile.Services.Requests.Chamada
{
    public class ChamadaRequest
    {
        public ChamadaRequest(int alunoId, int licaoId, bool estavaPresente, IEnumerable<int> avaliacoes)
        {
            AlunoId = alunoId;
            LicaoId = licaoId;
            EstavaPresente = estavaPresente;
            Avaliacoes = avaliacoes;
        }

        public int AlunoId { get; private set; }
        public int LicaoId { get; private set; }
        public bool EstavaPresente { get; private set; }
        public IEnumerable<int> Avaliacoes { get; private set; }
    }
}
