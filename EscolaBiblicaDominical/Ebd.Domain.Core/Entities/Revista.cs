using System.Collections.Generic;

namespace Ebd.Domain.Core.Entities
{
    public class Revista
    {
        public Revista(int turmaId, string sumario, int ano, int trimestre)
        {
            TurmaId = turmaId;
            Sumario = sumario;
            Ano = ano;
            Trimestre = trimestre;
        }

        public Revista(int turmaId, int revistaId, string sumario, int ano, int trimestre)
        {
            TurmaId = turmaId;
            RevistaId = revistaId;
            Sumario = sumario;
            Ano = ano;
            Trimestre = trimestre;
        }

        public int RevistaId { get; private set; }
        public string Sumario { get; private set; }
        public int Ano { get; private set; }
        public int Trimestre { get; private set; }

        public int TurmaId { get; private set; }
        public Turma Turma { get; private set; }
        public ICollection<Licao> Licoes { get; private set; }
    }
}
