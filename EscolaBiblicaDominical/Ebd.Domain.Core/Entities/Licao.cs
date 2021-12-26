namespace Ebd.Domain.Core.Entities
{
    public class Licao
    {
        public Licao(string titulo, int revistaId)
        {
            Titulo = titulo;
            RevistaId = revistaId;
        }

        public int LicaoId { get; private set; }
        public string Titulo { get; private set; }

        public int RevistaId { get; private set; }
        public Revista Revista { get; private set; }
    }
}
