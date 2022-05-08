using Ebd.Application.Business.Interfaces;
using Ebd.Application.Requests.Chamada;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Ebd.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChamadaController : BaseController
    {
        private readonly IChamadaBusiness _chamadaBusiness;

        public ChamadaController(ILogger<BaseController> logger, IChamadaBusiness chamadaBusiness) : base(logger)
        {
            _chamadaBusiness = chamadaBusiness;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EfetuarChamadaRequest request)
        {
            try
            {
                return ResultWhenAdding(await _chamadaBusiness.EfetuarChamadaAsync(request));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Erro ao efetuar chamada");
                return InternalServerError(ex, "Erro ao efetuar chamada");
            }
        }
    }
}
