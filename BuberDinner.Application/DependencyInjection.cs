using Microsoft.Extensions.DependencyInjection;
using MediatR;

using SmartRMS.Application.Common.Behaviors;
using ErrorOr;
using FluentValidation;
using System.Reflection;
using SmartRMS.Application.Common.Interfaces.Persistence;
using SmartRMS.Application.Authentication.Commands.Tabel;
using SmartRMS.Application.Authentication.Commands.Category;
using SmartRMS.Application.Authentication.Commands.Menu;

namespace SS_RMS.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddScoped<IDTabelHandler, TabelHandler>();
        services.AddScoped<IDCategoryHandler, CategoryHandler>();
        services.AddScoped<IMenuHandler, MenuHandler>();
        services.AddScoped(
        typeof(IPipelineBehavior<,>),
        typeof(ValidationBehaviors<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
          return  services;
    }


}