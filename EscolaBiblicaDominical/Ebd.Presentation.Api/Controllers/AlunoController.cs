using Ebd.Application.Business.Interfaces;
using Ebd.Application.Requests.Aluno;
using Ebd.Application.Responses;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Ebd.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    public class AlunoController : BaseController
    {
        private readonly IAlunoBusiness _alunoBusiness;

        public AlunoController(ILogger<BaseController> logger, IAlunoBusiness alunoBusiness) : base(logger)
        {
            _alunoBusiness = alunoBusiness;
        }

        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(AlunoResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] AdicionarAlunoRequest request)
        {
            try
            {
                return ResultWhenAdding(await _alunoBusiness.Adicionar(request));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao adicionar aluno");
                return InternalServerError(ex);
            }
        }

        [Route("turma/{turmaId:int}")]
        [HttpGet]
        [ProducesResponseType(typeof(AlunoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationFailure>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] int turmaId)
        {
            try
            {
                return ResultWhenSearching(await _alunoBusiness.ObterPorTurma(turmaId));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao obter aluno por turma");
                return InternalServerError(ex);
            }
        }
    }
}
