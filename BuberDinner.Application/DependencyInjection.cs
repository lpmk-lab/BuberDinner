using SS_RMS.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace SS_RMS.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
          services.AddScoped<IAuthenticationService,AuthenticationService>();
          return  services;
    }


}