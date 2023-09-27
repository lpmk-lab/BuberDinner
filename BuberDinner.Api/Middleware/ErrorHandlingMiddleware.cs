
using System.Net;
using System.Text.Json;

namespace SS_RMS.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {

        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context )
        {
            try
            {
              await _next(context);
            }
            catch (Exception ex)
            {
                await handlExceptionAsync(context, ex);
            }
        }

        public static Task handlExceptionAsync(HttpContext context, Exception ex)
        {

            var code = HttpStatusCode.InternalServerError;
            var result = JsonSerializer.Serialize(new{ error = "An Error Occur when processing your request" });
            context.Response.ContentType= "application/json";
            context.Response.StatusCode=(int)code;
            return context.Response.WriteAsJsonAsync(result);
        }



    }
}
