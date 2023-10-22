using Mapster;
using SmartRMS.Application.Authentication.Commands.Commons;
using SmartRMS.Application.Authentication.Commands.Login;
using SmartRMS.Application.Authentication.Commands.Register;
using SmartRMS.Domain.Models;
using SS_RMS.Contracts.Authentication;
using SS_RMS.Domain.Entities;

namespace SmartRMS.Api.Common.Mapping;
public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.user);

    }
}

