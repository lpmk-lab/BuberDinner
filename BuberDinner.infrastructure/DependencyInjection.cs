using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;
namespace BuberDinner.infrastructure;


public static class DependencyInjection{

    public static IServiceCollection AddInfrastructure(this IServiceCollection service){
        service.AddSingleton<IJWTokenGenerator, JWTokenGenerator>();
        return service;
    }

}