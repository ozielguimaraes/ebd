﻿using Ebd.Application.Business.Interfaces;
using Ebd.Application.Requests.Revista;
using Ebd.Application.Responses.Revista;
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
    public class RevistaController : BaseController
    {
        private readonly IRevistaBusiness _revistaBusiness;

        public RevistaController(ILogger<BaseController> logger, IRevistaBusiness revistaBusiness) : base(logger)
        {
            _revistaBusiness = revistaBusiness;
        }


        [Route("{revistaId:int}")]
        [HttpGet]
        [ProducesResponseType(typeof(RevistaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] int revistaId)
        {
            try
            {
                return ResultWhenSearching(await _revistaBusiness.ObterPorId(revistaId));
            }
            catch (Exception ex)
            {
                var message = $"Erro ao obter lições da revista: {revistaId}";
                Logger.LogError(ex, message);
                return InternalServerError(ex, message);
            }
        }

        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(RevistaResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] AdicionarRevistaRequest request)
        {
            try
            {
                return ResultWhenAdding(await _revistaBusiness.AdicionarAsync(request));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao adicionar revista");
                return InternalServerError(ex, "Erro ao adicionar revista");
            }
        }

        [Route("turma/{turmaId:int}/trimestre/{trimestre:int}-{ano:int}")]
        [HttpGet]
        [ProducesResponseType(typeof(RevistaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] int turmaId, [FromRoute] int ano, [FromRoute] int trimestre)
        {
            try
            {
                return ResultWhenSearching(await _revistaBusiness.ObterPorPeriodo(turmaId, ano, trimestre));
            }
            catch (Exception ex)
            {
                var message = $"Erro ao obter as revistas do periodo turma/{turmaId}/trimestre/{trimestre}-{ano}";
                Logger.LogError(ex, message);
                return InternalServerError(ex, message);
            }
        }
    }
}
