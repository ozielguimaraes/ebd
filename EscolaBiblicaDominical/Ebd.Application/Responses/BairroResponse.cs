using Ebd.Application.Responses.Base;
using FluentValidation.Results;

namespace Ebd.Application.Responses
{
    public class BairroResponse : BaseResponse
    {
        public BairroResponse(ValidationResult validationResult) : base(validationResult) { }

        public BairroResponse(int bairroId, string nome)
        {
            BairroId = bairroId;
            Nome = nome;
        }

        public int BairroId { get; private set; }
        public string Nome { get; private set; }
    }
}
