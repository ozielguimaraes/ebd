using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ebd.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevistaController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WeatherForecast weatherForecast)
        {
            try
            {
                await Task.Delay(1000);
                return Ok("Revista: OK deu bão");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
