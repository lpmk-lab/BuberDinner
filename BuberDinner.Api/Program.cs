
using SS_RMS.Application;
using SS_RMS.infrastructure;

using SS_RMS.Api;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentaion()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
        //builder.Services.AddControllers(options=>options.Filters.Add<ErrorHandlingFilter>());
  
}


var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();

}
