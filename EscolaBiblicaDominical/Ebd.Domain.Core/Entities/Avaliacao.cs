using System.Collections.Generic;

namespace Ebd.Domain.Core.Entities
{
    public class Avaliacao
    {
        public Avaliacao(int avaliacaoId, int nota, string nome)
        {
            AvaliacaoId = avaliacaoId;
            Nota = nota;
            Nome = nome;
        }

        public int AvaliacaoId { get; private set; }
        public int Nota { get; private set; }
        public string Nome { get; private set; }
        public IEnumerable<AvaliacaoAluno> AvaliacoesAluno { get; set; }
    }
}
