using Ebd.Application.Business.Interfaces;
using Ebd.Application.Responses.Avaliacao;
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
    public class AvaliacaoController : BaseController
    {
        private readonly IAvaliacaoBusiness _avaliacaoBusiness;

        public AvaliacaoController(ILogger<BaseController> logger, IAvaliacaoBusiness avaliacaoBusiness) : base(logger)
        {
            _avaliacaoBusiness = avaliacaoBusiness; ;
        }

        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(ObterTodasResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return ResultWhenSearching(await _avaliacaoBusiness.ObterTodasAsync());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao obter as avaliações");
                return InternalServerError(ex, "Erro ao obter as avaliações");
            }
        }
    }
}
