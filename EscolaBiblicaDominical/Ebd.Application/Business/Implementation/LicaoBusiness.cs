using Ebd.Application.Business.Interfaces;
using Ebd.Application.Mappers;
using Ebd.Application.Requests.Licao;
using Ebd.Application.Responses.Base;
using Ebd.Application.Responses.Licao;
using Ebd.Application.Validations.Licao;
using Ebd.Domain.Core.Entities;
using Ebd.Domain.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Application.Business.Implementation
{
    public class LicaoBusiness : ILicaoBusiness
    {
        private readonly ILicaoRepository _licaoRepository;

        public LicaoBusiness(ILicaoRepository licaoRepository)
        {
            _licaoRepository = licaoRepository;
        }

        public async Task<BaseResponse> AdicionarAsync(AdicionarLicaoRequest request)
        {
            var validator = new AdicionarLicaoValidation();
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid) return new ValidationResponse(validationResult);

            var result = await _licaoRepository.Adicionar(new Licao(request.Titulo, request.RevistaId));
            return LicaoMapper.FromEntityToResponse(result);
        }

        public async Task<IEnumerable<LicaoResponse>> ObterPorRevista(int revistaId)
        {
            var result = await _licaoRepository.ObterPorRevista(revistaId);
            return LicaoMapper.FromEntityToResponse(result);
        }
    }
}
