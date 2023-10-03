

using ErrorOr;
using MediatR;
using SS_RMS.Application.Common.Interfaces.Authentication;
using SS_RMS.Application.Common.Interfaces.Persistence;
using SmartRMS.Domain.Common.Errors;
using SS_RMS.Domain.Entities;
using SmartRMS.Application.Authentication.Commands.Commons;

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
        if (_IUserRepository.GetUserByEmail(command.Email) != null)
        {
            return Errors.User.DuplicateEmail;
        }

        //Create User(Generate Unique GUID)  & Persit to DB
        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };

        _IUserRepository.AddUser(user);
        //Create  JWtoken

        var token = _IJWTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
           user,
           token
          );
    }
}

