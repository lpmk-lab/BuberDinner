using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BuberDinner.Api.Filters
{
    public class ErrorHandlingFilter: ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
           var exception= context.Exception;

            var problemDetails = new ProblemDetails
            {
                Type= "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                Title = "An Error Occur when processing your request",
                Status=(int)HttpStatusCode.InternalServerError,


            };

            context.Result = new ObjectResult(problemDetails)
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;

        }
    }
}
