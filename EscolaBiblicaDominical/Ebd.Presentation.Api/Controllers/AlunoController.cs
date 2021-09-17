using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebd.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    public class AlunoController : BaseController
    {
        public AlunoController(ILogger<BaseController> logger) : base(logger)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WeatherForecast weatherForecast)
        {
            try
            {
                await Task.Delay(1000);
                throw new Exception();
                return Ok("Aluno: OK deu bão");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao adicionar aluno");
                return BadRequest(ex.Message);
            }
        }
    }
}
