using System.Collections.Generic;

namespace Ebd.Application.Requests.Chamada
{
    public class EfetuarChamadaRequest
    {
        public int AlunoId { get; set; }
        public int LicaoId { get; set; }
        public bool EstavaPresente { get; set; }
        public IEnumerable<int> Avaliacoes { get; set; }
    }
}
