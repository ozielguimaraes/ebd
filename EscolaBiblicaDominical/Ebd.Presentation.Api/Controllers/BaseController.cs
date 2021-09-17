using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ebd.Presentation.Api.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly ILogger Logger;

        protected BaseController(ILogger<BaseController> logger)
        {
            Logger = logger;
        }
    }
}
