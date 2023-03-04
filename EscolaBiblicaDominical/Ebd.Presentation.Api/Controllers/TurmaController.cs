using Ebd.Application.Business.Interfaces;
using Ebd.Application.Requests.Turma;
using Ebd.Application.Responses.Turma;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : BaseController
    {
        private readonly ITurmaBusiness _turmaBusiness;

        public TurmaController(ILogger<BaseController> logger, ITurmaBusiness turmaBusiness) : base(logger)
        {
            _turmaBusiness = turmaBusiness;
        }

        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(TurmaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Post([FromBody] AdicionarTurmaRequest request)
        {
            try
            {
                return ResultWhenAdding(await _turmaBusiness.AdicionarAsync(request));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao adicionar turma");
                return InternalServerError(ex, "Erro ao adicionar turma");
            }
        }

        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(TurmaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return ResultWhenSearching(await _turmaBusiness.ObterTodas());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao obter todas turmas");
                return InternalServerError(ex, "Erro ao obter todas turmas");
            }
        }
    }
}
