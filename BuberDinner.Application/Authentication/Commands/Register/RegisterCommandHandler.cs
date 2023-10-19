

using ErrorOr;
using MediatR;
using SS_RMS.Application.Common.Interfaces.Authentication;
using SS_RMS.Application.Common.Interfaces.Persistence;
using SmartRMS.Domain.Common.Errors;
using SS_RMS.Domain.Entities;
using SmartRMS.Application.Authentication.Commands.Commons;
using SmartRMS.Domain.Models;

namespace SmartRMS.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJWTokenGenerator _IJWTokenGenerator;
    private readonly IUserRepository _IUserRepository;
    public RegisterCommandHandler(IJWTokenGenerator IJWTokenGenerator, IUserRepository IUserRepository)
    {
        _IJWTokenGenerator = IJWTokenGenerator;
        _IUserRepository = IUserRepository;
    }
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
         await Task.CompletedTask;
        if (_IUserRepository.GetUserByEmailCheck(command.Email) == true)
        {
            return Errors.User.DuplicateEmail;
        }

        //Create User(Generate Unique GUID)  & Persit to DB
        var user = new SysUser
        {
            UserCode = command.FirstName + " " + command.LastName ,
            UserName = command.FirstName + " " + command.LastName ,
            Email = command.Email,
            Password = command.Password
        };

        user=_IUserRepository.AddUser(user);
        //Create  JWtoken

        var token = _IJWTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
           user,
           token
          );
    }
}

