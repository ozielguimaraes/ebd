using Ebd.Application.Business.Interfaces;
using Ebd.Application.Requests.Aluno;
using Ebd.Application.Responses.Aluno;
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
    public class AlunoController : BaseController
    {
        private readonly IAlunoBusiness _alunoBusiness;

        public AlunoController(ILogger<AlunoController> logger, IAlunoBusiness alunoBusiness) : base(logger)
        {
            _alunoBusiness = alunoBusiness;
        }

        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(ListaAlunoResponse), StatusCodes.Status201Created)]
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
                return InternalServerError(ex, "Erro ao adicionar aluno");
            }
        }

        [Route("{alunoId:int}")]
        [HttpGet]
        [ProducesResponseType(typeof(ListaAlunoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromRoute] int alunoId)
        {
            try
            {
                return ResultWhenSearching(await _alunoBusiness.ObterPorId(alunoId));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao obter aluno por Id");
                return InternalServerError(ex, "Erro ao obter aluno por Id");
            }
        }

        [Route("turma/{turmaId:int}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ListaAlunoResponse>), StatusCodes.Status200OK)]
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
                return InternalServerError(ex, "Erro ao obter aluno por turma");
            }
        }
    }
}
