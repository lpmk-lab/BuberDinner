using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Services;
using BuberDinner.infrastructure.Authentication;
using BuberDinner.Infrastructure.Authentication;
using BuberDinner.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace BuberDinner.infrastructure;


public static class DependencyInjection{

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection service, 
        ConfigurationManager configuration)
    {

        service.Configure<JwtSetting>(configuration.GetSection(JwtSetting.SectionName));
        service.AddSingleton<IJWTokenGenerator, JWTokenGenerator>();
        service.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return service;
    }

}