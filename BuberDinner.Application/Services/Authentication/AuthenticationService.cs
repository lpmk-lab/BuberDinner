using BuberDinner.Application.Common.Errors;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
using FluentResults;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{


    private readonly IJWTokenGenerator _IJWTokenGenerator;
    private readonly IUserRepository _IUserRepository;
    public AuthenticationService(IJWTokenGenerator IJWTokenGenerator, IUserRepository IUserRepository)
    {
          _IJWTokenGenerator=IJWTokenGenerator;
        _IUserRepository = IUserRepository;
    }
    public AuthenticationResult Login(string Email, string Password)
    {
       //1 Validate User Exit
       if(_IUserRepository.GetUserByEmail(Email) is not User user) 
        {
            throw new Exception("User With Given Emial is Does not Exit");
        }

       //2 Validate Password Is Correct
       if(user.Password != Password)
        {
            throw new Exception("Password is Invaild");

        }
       //3 Create Token
        var token = _IJWTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
            );
     }

    public Result<AuthenticationResult> Register(string FirstName, string LastName, string Email, string Password)
    {
      
      //Check if User Already Exist
      if(_IUserRepository.GetUserByEmail(Email) != null)
        {
            return Result.Fail<AuthenticationResult>(new[] { new DuplicateEmailError() });
        }

      //Create User(Generate Unique GUID)  & Persit to DB
      var user=new User { 
          FirstName = FirstName,
          LastName = LastName,
          Email = Email,
          Password = Password };

        _IUserRepository.AddUser(user);
      //Create  JWtoken
   
      var token=_IJWTokenGenerator.GenerateToken(user);

          return new AuthenticationResult(
             user,
             token
            );
    }
}
