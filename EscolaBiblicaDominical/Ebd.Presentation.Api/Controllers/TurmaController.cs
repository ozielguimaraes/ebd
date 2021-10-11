using Ebd.Application.Business.Interfaces;
using Ebd.Application.Responses;
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
                return InternalServerError(ex);
            }
        }
    }
}
