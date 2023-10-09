using SS_RMS.Application.Common.Interfaces.Authentication;
using SS_RMS.Application.Common.Interfaces.Persistence;
using SS_RMS.Application.Common.Interfaces.Services;
using SS_RMS.infrastructure.Authentication;
using SS_RMS.Infrastructure.Authentication;
using SS_RMS.Infrastructure.Persistence;
using SS_RMS.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Text;

namespace SS_RMS.infrastructure;


public static class DependencyInjection{

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection service, 
        ConfigurationManager configuration)
    {

        service.AddAuth(configuration);
       
        service.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        service.AddScoped<IUserRepository, UserRepository>();
        return service;
    }
    public static IServiceCollection AddAuth(
        this IServiceCollection service,
        ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSetting();
        configuration.Bind(JwtSetting.SectionName,jwtSettings);
        service.AddSingleton(Options.Create(jwtSettings));
        service.AddSingleton<IJWTokenGenerator, JWTokenGenerator>();

        service.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                //ValidateIssuerSigningKey= true,
                //IssuerSigningKey=new SymmetricSecurityKey(
                //    Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });

        return service;
    }

}