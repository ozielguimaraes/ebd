using Ebd.Application.Business.Interfaces;
using Ebd.Application.Requests.Licao;
using Ebd.Application.Responses.Licao;
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
    public class LicaoController : BaseController
    {
        private readonly ILicaoBusiness _licaoBusiness;

        public LicaoController(ILogger<BaseController> logger, ILicaoBusiness licaoBusiness) : base(logger)
        {
            _licaoBusiness = licaoBusiness;
        }

        [Route("revista/{revistaId:int}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LicaoResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] int revistaId)
        {
            try
            {
                return ResultWhenSearching(await _licaoBusiness.ObterPorRevista(revistaId));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Erro ao obter lições da revista: {revistaId}");
                return InternalServerError(ex, $"Erro ao obter lições da revista: {revistaId}");
            }
        }

        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(LicaoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] AdicionarLicaoRequest request)
        {
            try
            {
                return ResultWhenAdding(await _licaoBusiness.AdicionarAsync(request));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao adicionar lição.");
                return InternalServerError(ex, "Erro ao adicionar lição");
            }
        }
    }
}
