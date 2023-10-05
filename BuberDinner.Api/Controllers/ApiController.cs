
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SmartRMS.Api.Common.Https;

namespace SmartRMS.Api.Controllers;
[ApiController]
public class ApiController:ControllerBase
    {

    protected IActionResult Problem(List<Error> errors)
    {
        if(errors.Count is 0)
        {
            return Problem();
        }
        if (errors.All(error => error.Type == ErrorType.Validation))
        {
            return ValidationProblem(errors);

        }
        HttpContext.Items[HttpContextItemsKeys.Errors] = errors;

        return Problem(errors[0]);

    }

    private IActionResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError

        };
        return Problem(statusCode: statusCode, title: error.Description);
    }

    private IActionResult ValidationProblem(List<Error> errors)
    {
        var modelStateDictionary = new ModelStateDictionary();
        foreach (var error in errors)
        {
            modelStateDictionary.AddModelError(
                error.Code,
                error.Description
                );
        }
        return ValidationProblem(modelStateDictionary);
    }
}

