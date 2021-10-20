using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Ebd.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : BaseController
    {
        public PessoaController(ILogger<BaseController> logger) : base(logger)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WeatherForecast weatherForecast)
        {
            try
            {
                await Task.Delay(1000);
                return Ok("Pessoa: OK deu bão");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao obter aluno por turma");
                return InternalServerError(ex);
            }
        }
    }
}
