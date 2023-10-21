
using ErrorOr;
using MediatR;
using SmartRMS.Application.Authentication.Commands.Register;
using SS_RMS.Application.Common.Interfaces.Authentication;
using SS_RMS.Application.Common.Interfaces.Persistence;
using SmartRMS.Domain.Common.Errors;
using SS_RMS.Domain.Entities;
using SmartRMS.Application.Authentication.Commands.Commons;
using SmartRMS.Domain.Models;
using SmartRMS.Application.Common.Interfaces.Authentication;

namespace SmartRMS.Application.Authentication.Commands.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJWTokenGenerator _IJWTokenGenerator;
    private readonly IUserRepository _IUserRepository;
    private readonly IDecryption _IDecryption;
    private readonly Smart_RMS_SignOnContext _DBSigOnContext;
    public LoginQueryHandler(IJWTokenGenerator IJWTokenGenerator, IUserRepository IUserRepository, Smart_RMS_SignOnContext DBSigOnContext, IDecryption IDecryption)
    {
        _IJWTokenGenerator = IJWTokenGenerator;
        _IUserRepository = IUserRepository;
        _DBSigOnContext= DBSigOnContext;
        _IDecryption = IDecryption;
    }
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_IUserRepository.GetUserByEmail(query.Email) is not SysUser user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        //2 Validate Password Is Correct
        if (_IDecryption.Decrypt(user.Password) != query.Password)
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

