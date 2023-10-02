
using ErrorOr;
using MediatR;
using SmartRMS.Application.Authentication.Commands.Register;
using SS_RMS.Application.Common.Interfaces.Authentication;
using SS_RMS.Application.Common.Interfaces.Persistence;
using SmartRMS.Domain.Common.Errors;
using SS_RMS.Domain.Entities;
using SmartRMS.Application.Authentication.Commands.Commons;

namespace SmartRMS.Application.Authentication.Commands.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJWTokenGenerator _IJWTokenGenerator;
    private readonly IUserRepository _IUserRepository;
    public LoginQueryHandler(IJWTokenGenerator IJWTokenGenerator, IUserRepository IUserRepository)
    {
        _IJWTokenGenerator = IJWTokenGenerator;
        _IUserRepository = IUserRepository;
    }
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (_IUserRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        //2 Validate Password Is Correct
        if (user.Password != query.Password)
        {
            return new[] { Errors.Authentication.InvalidCredentials };

        }
        //3 Create Token
        var token = _IJWTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
            );
    }
}

