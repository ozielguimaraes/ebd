using Ebd.Application.Business.Interfaces;
using Ebd.Application.Mappers;
using Ebd.Application.Requests.Aluno;
using Ebd.Application.Responses;
using Ebd.Application.Validations.Aluno;
using Ebd.Domain.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Application.Business.Implementation
{
    public class AlunoBusiness : IAlunoBusiness
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoBusiness(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<AlunoResponse> Adicionar(AdicionarAlunoRequest request)
        {
            var validator = new AdicionarAlunoValidation();
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid) return new AlunoResponse(validationResult);

            var response = await _alunoRepository.Adicionar(AlunoMapper.FromRequestToEntity(request));

            return AlunoMapper.FromEntityToResponse(response);
        }

        public async Task<IEnumerable<AlunoResponse>> ObterPorTurma(int turmaId)
        {
            var result = await _alunoRepository.ObterPorTurma(turmaId);

            return AlunoMapper.FromEntityToResponse(result);
        }
    }
}
