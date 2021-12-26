using Ebd.Application.Responses.Base;

namespace Ebd.Application.Responses.Licao
{
    public class LicaoResponse : BaseResponse
    {
        public LicaoResponse(int licaoId, string titulo, int revistaId)
        {
            LicaoId = licaoId;
            Titulo = titulo;
            RevistaId = revistaId;
        }

        public int LicaoId { get; private set; }
        public string Titulo { get; private set; }
        public int RevistaId { get; private set; }
    } 
}
