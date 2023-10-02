
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using SmartRMS.Api.Common.Https;

namespace SmartRMS.Api.Controllers;
[ApiController]
public class ApiController:ControllerBase
    {

    protected IActionResult Problem(List<Error> errors)
    {
        HttpContext.Items[HttpContextItemsKeys.Errors]=errors;
        var firstError = errors[0];

        var statusCode = firstError.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError

        };
        return Problem(statusCode: statusCode, title:firstError.Description) ;

    }
    }

