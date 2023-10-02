using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace SS_RMS.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
          return  services;
    }


}