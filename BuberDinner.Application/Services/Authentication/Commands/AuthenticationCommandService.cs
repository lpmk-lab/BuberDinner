using ErrorOr;
using SmartRMS.Domain.Common.Errors;
using SS_RMS.Domain.Entities;
using SS_RMS.Application.Common.Interfaces.Authentication;
using SS_RMS.Application.Common.Interfaces.Persistence;
using SmartRMS.Application.Services.Authentication.Commons;

namespace SmartRMS.Application.Services.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{


    private readonly IJWTokenGenerator _IJWTokenGenerator;
    private readonly IUserRepository _IUserRepository;
    public AuthenticationCommandService(IJWTokenGenerator IJWTokenGenerator, IUserRepository IUserRepository)
    {
        _IJWTokenGenerator = IJWTokenGenerator;
        _IUserRepository = IUserRepository;
    }
    

    public ErrorOr<AuthenticationResult> Register(string FirstName, string LastName, string Email, string Password)
    {

        //Check if User Already Exist
        if (_IUserRepository.GetUserByEmail(Email) != null)
        {
            return Errors.User.DuplicateEmail;
        }

        //Create User(Generate Unique GUID)  & Persit to DB
        var user = new User
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            Password = Password
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
