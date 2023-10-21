
using SS_RMS.Application.Common.Interfaces.Persistence;
using SS_RMS.Application.Common.Interfaces.Services;
using SS_RMS.Infrastructure.Persistence;
using SS_RMS.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SS_RMS.Infrastructure.Authentication;
using Microsoft.Extensions.Options;
using SS_RMS.Application.Common.Interfaces.Authentication;
using SS_RMS.infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SmartRMS.Domain.Models;
using SmartRMS.Infrastructure.Authentication;
using SmartRMS.Application.Common.Interfaces.Authentication;

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
        this IServiceCollection services,
        ConfigurationManager configuration
    )
    {
        #region DB Connection
        services.AddDbContext<Smart_RMS_SignOnContext>(
        options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
        #endregion
        #region Token Generator
        var jwtSettings = new JwtSetting();
        configuration.Bind(JwtSetting.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));


        services.AddSingleton<IJWTokenGenerator, JWTokenGenerator>();

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

        }

            ).AddJwtBearer(x => {

                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
                };




            });

        services.AddAuthorization();
        #endregion
        #region Encryption
        var encryptionSettings = new EncryptionSettings();
        configuration.Bind(EncryptionSettings.SectionName, encryptionSettings);

        services.AddSingleton(Options.Create(encryptionSettings));
        services.AddSingleton<IEncryption, Encryption>();
        services.AddSingleton<IDecryption, Decryption>();

        #endregion

        return services;
    }

}