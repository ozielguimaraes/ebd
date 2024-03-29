﻿using Ebd.Application.Business.Interfaces;
using Ebd.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Ebd.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    public class BairroController : BaseController
    {
        private readonly IBairroBusiness _bairroBusiness;

        public BairroController(ILogger<BaseController> logger, IBairroBusiness bairroBusiness) : base(logger)
        {
            _bairroBusiness = bairroBusiness;
        }

        [Route("")]
        [HttpGet]
        [ProducesResponseType(typeof(BairroResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            try
            {
                return ResultWhenSearching(await _bairroBusiness.ObterTodosAsync());
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao obter os bairros");
                return InternalServerError(ex, "Erro ao obter os bairros");
            }
        }
    }
}
