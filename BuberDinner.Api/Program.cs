using SS_RMS.Api.Common.Errors;
using SS_RMS.Api.Filters;
using SS_RMS.Api.Middleware;
using SS_RMS.Application;
using SS_RMS.infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
        //builder.Services.AddControllers(options=>options.Filters.Add<ErrorHandlingFilter>());
    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory,SS_RMSProblemDetailsFactory>();
}


var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();

}
