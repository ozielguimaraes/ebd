using System.Collections.Generic;

namespace Ebd.Domain.Core.Entities
{
    public class Revista
    {
        public int RevistaId { get; private set; }
        public string Sumario { get; private set; }
        public int Ano { get; private set; }
        public int Trimestre { get; private set; }
        public ICollection<Licao> Licoes { get; private set; }
    }
}
