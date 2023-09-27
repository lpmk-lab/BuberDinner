using SS_RMS.Application.Common.Interfaces.Authentication;
using SS_RMS.Application.Common.Interfaces.Persistence;
using SS_RMS.Application.Common.Interfaces.Services;
using SS_RMS.infrastructure.Authentication;
using SS_RMS.Infrastructure.Authentication;
using SS_RMS.Infrastructure.Persistence;
using SS_RMS.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace SS_RMS.infrastructure;


public static class DependencyInjection{

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection service, 
        ConfigurationManager configuration)
    {

        service.Configure<JwtSetting>(configuration.GetSection(JwtSetting.SectionName));
        service.AddSingleton<IJWTokenGenerator, JWTokenGenerator>();
        service.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        service.AddScoped<IUserRepository, UserRepository>();
        return service;
    }

}