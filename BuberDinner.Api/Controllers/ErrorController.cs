using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SS_RMS.Application.Common.Errors;

namespace SS_RMS.Api.Controllers
{
    public class ErrorController:ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
          
            return Problem();

        }

    }
}
