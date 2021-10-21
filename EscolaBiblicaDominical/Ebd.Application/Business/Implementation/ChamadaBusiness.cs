using Ebd.Application.Business.Interfaces;
using Ebd.Application.Requests.Chamada;
using Ebd.Application.Responses.Chamada;
using Ebd.Application.Validations.Chamada;
using Ebd.Domain.Core.Entities;
using Ebd.Domain.Core.Interfaces.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ebd.Application.Business.Implementation
{
    public class ChamadaBusiness : IChamadaBusiness
    {
        private readonly IChamadaRepository _chamadaRepository;
        private readonly IAvaliacaoAlunoBusiness _avaliacaoAlunoBusiness;

        public ChamadaBusiness(IChamadaRepository chamadaRepository, IAvaliacaoAlunoBusiness avaliacaoAlunoBusiness)
        {
            _chamadaRepository = chamadaRepository;
            _avaliacaoAlunoBusiness = avaliacaoAlunoBusiness;
        }

        public async Task<EfetuarChamadaResponse> EfetuarChamadaAsync(EfetuarChamadaRequest request)
        {
            var validator = new EfetuarChamadaValidation();
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid) return new EfetuarChamadaResponse(validationResult);

            //TODO fazer transaction Scope
            var efetuarChamadaResult = await AdicionarAsync(new Chamada(
                alunoId: request.AlunoId,
                licaoId: request.LicaoId,
                estavaPresente: request.EstavaPresente,
                data: DateTime.UtcNow
                ));
            if (request.EstavaPresente)
                await _avaliacaoAlunoBusiness.AdicionarAsync(request.AlunoId, request.Avaliacoes);

            //------
            //TODO fazer transaction Scope

            return new EfetuarChamadaResponse(efetuarChamadaResult.ChamadaId);
        }

        private async Task<Chamada> AdicionarAsync(Chamada chamada)
            => await _chamadaRepository.AdicionarAsync(chamada);
    }
}
