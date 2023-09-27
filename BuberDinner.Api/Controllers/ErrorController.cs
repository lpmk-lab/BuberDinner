using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BuberDinner.Application.Common.Errors;

namespace BuberDinner.Api.Controllers
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
