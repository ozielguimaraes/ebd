using Ebd.Application.Responses.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

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

        protected ObjectResult ResultWhenAdding(BaseResponse response)
        {
            if (response.ValidationResult.IsValid)
            {
                Logger.LogInformation($"item added: {response}");
                return StatusCode(StatusCodes.Status201Created, response);
            }

            return BadRequest(response.ValidationResult.Errors);
        }

        protected ObjectResult InternalServerError(Exception exception)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, exception);
        }
    }
}
