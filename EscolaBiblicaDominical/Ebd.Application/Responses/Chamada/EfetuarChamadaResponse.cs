using Ebd.Application.Responses.Base;
using FluentValidation.Results;

namespace Ebd.Application.Responses.Chamada
{
    public class EfetuarChamadaResponse : BaseResponse
    {
        public EfetuarChamadaResponse(ValidationResult validationResult) : base(validationResult) { }
        public EfetuarChamadaResponse(int chamadaId)
        {
            ChamadaId = chamadaId;
        }

        public int ChamadaId { get; private set; }
    }
}
