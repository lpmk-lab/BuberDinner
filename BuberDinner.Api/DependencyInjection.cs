

using Microsoft.AspNetCore.Mvc.Infrastructure;
using SmartRMS.Api.Common.Mapping;
using SS_RMS.Api.Common.Errors;

namespace SS_RMS.Api;

public static class DependencyInjection
{

    public static IServiceCollection AddPresentaion(this IServiceCollection services)
    {
        services.AddControllers();
       

        services.AddSingleton<ProblemDetailsFactory, SS_RMSProblemDetailsFactory>();
        services.AddMappings();
        return  services;
    }


}