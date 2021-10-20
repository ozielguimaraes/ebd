using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Ebd.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    public class InfoController : BaseController
    {
        public InfoController(ILogger<BaseController> logger) : base(logger)
        {
        }

        [HttpGet("")]
        public ActionResult<string> Info()
        {
            var assembly = typeof(Startup).Assembly;

            var creationDate = System.IO.File.GetCreationTime(assembly.Location);
            var version = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;

            return Ok($"Version: {version}, Last Updated: {creationDate}");
        }
    }
}
