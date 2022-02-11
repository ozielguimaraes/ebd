using Ebd.Application.Responses.Base;
using Ebd.Presentation.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
            if (response.IsValid())
            {
                Logger.LogInformation($"item added: {response}");
                response.SetValidationResult(null);
                return StatusCode(StatusCodes.Status201Created, response);
            }

            return BadRequest(response.GetValidationFailures());
        }

        protected ObjectResult ResultWhenSearching(BaseResponse response)
        {
            return Ok(response);
        }

        protected ObjectResult ResultWhenSearching(IEnumerable<BaseResponse> response)
        {
            return Ok(response);
        }

        protected ObjectResult InternalServerError(Exception exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, exception.FullException());
        }
    }
}
