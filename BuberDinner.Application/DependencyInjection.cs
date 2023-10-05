using Microsoft.Extensions.DependencyInjection;
using MediatR;
using SmartRMS.Application.Authentication.Commands.Register;
using SmartRMS.Application.Authentication.Commands.Commons;
using SmartRMS.Application.Common.Behaviors;
using ErrorOr;
using FluentValidation;
using System.Reflection;

namespace SS_RMS.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddScoped(
        typeof(IPipelineBehavior<,>),
        typeof(ValidationBehaviors<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
          return  services;
    }


}